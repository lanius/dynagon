using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dynagon {

	public abstract class Polygon {

		public GameObject gameObject;

		public List<Vector3> vertices;
		public List<int> indexes;

		protected Polygon(GameObject gameObject) {
			gameObject.AddComponent<MeshFilter>();
			
			var renderer = gameObject.AddComponent<MeshRenderer>();
			renderer.material = new Material(Shader.Find("Diffuse"));
			renderer.castShadows = true;
			renderer.receiveShadows = true;
			
			var collider = gameObject.AddComponent<MeshCollider>();
			collider.convex = true;

			this.gameObject = gameObject;
		}

		public Polygon(GameObject gameObject, List<Vector3> vertices) : this(gameObject) {
			// todo: check a number of vertices is multiple of 3
			this.vertices = vertices;
			indexes = Enumerable.Range(0, vertices.Count).ToList<int>();
		}

		protected Vector3 GetCenterOfTriangle(int firstIndexOfTriangle) {
			var i = firstIndexOfTriangle;
			return (vertices[i] + vertices[i + 1] + vertices[i + 2]) / 3;
		}
		
		protected Vector3 GetNormalOfTriangle(int firstIndexOfTriangle) {
			var i = firstIndexOfTriangle;
			return Vector3.Cross(vertices[i + 1] - vertices[i], vertices[i + 2] - vertices[i]);
		}

		protected void ReverseSurface(int firstIndexOfTriangle) {
			var i = firstIndexOfTriangle;
			int temp = indexes[i + 1];
			indexes[i + 1] = indexes[i + 2];
			indexes[i + 2] = temp;
		}

		protected abstract void OptimizeIndexes();
		
		protected void BuildMesh() {
			var mesh = gameObject.GetComponent<MeshFilter>().mesh;
			mesh.Clear();
			mesh.vertices = vertices.ToArray();
			mesh.triangles = indexes.ToArray();
			mesh.uv = new Vector2[mesh.vertices.Length];
			mesh.Optimize();
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();

			var m = new Mesh();
			m.vertices = vertices.ToArray();
			m.triangles = indexes.ToArray();
			gameObject.GetComponent<MeshCollider>().sharedMesh = m;
		}

		public Polygon Build() {
			OptimizeIndexes();
			BuildMesh();
			return this;
		}

		public Polygon Rigidize() {
			gameObject.AddComponent<Rigidbody>();
			return this;
		}

	}

}
