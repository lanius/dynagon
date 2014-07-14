using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Dynagon;

namespace Dynagon.Sample {

	public class Meteor : MonoBehaviour {
		
		public int numVertices = 15;
		public float radius = 3f;
		
		List<Vector3> vertices = new List<Vector3>();
		Polygon polygon;
		
		void Start() {
			for (int i = 0; numVertices > i; i++) {
				vertices.Add(Random.onUnitSphere * radius);
			}
			polygon = Factory.Create(gameObject, vertices);
		}
		
		void OnCollisionEnter(Collision col) {
			var contact = col.gameObject.transform.position - polygon.gameObject.transform.position;
			Split(contact);
		}
		
		void Split(Vector3 onePoint) {
			int[] p = new int[3];
			p[0] = GetNearest(onePoint);
			p[1] = GetFarthest(vertices[p[0]]);
			p[2] = GetFarthest((vertices[p[0]] + polygon.vertices[p[1]]) / 2);
			
			var center = (vertices[p[0]] + vertices[p[1]] + vertices[p[2]]) / 3;
			var norm = Vector3.Cross(vertices[p[1]] - vertices[p[0]], vertices[p[2]] - vertices[p[0]]) + center;
			
			List<Vector3>[] newVertices = {new List<Vector3>() {center}, new List<Vector3>() {center}};
			for (int i = 0; vertices.Count > i; i++) {
				if (i.Equals(p[0]) || i.Equals(p[1]) || i.Equals(p[2])) {
					newVertices[0].Add(vertices[i]);
					newVertices[1].Add(vertices[i]);
				}
				else if (Vector3.Dot(norm, vertices[i] - center) >= 0) {
					newVertices[0].Add(vertices[i]);
				}
				else {
					newVertices[1].Add(vertices[i]);
				}
			}
			
			var children = new List<Polygon>() {
				Factory.Create("Meteor Child", newVertices[0]),
				Factory.Create("Meteor Child", newVertices[1])
			};
			foreach (var c in children) {
				c.Rigidize();
				CopyFeature(c.gameObject);
			}
			Destroy(gameObject);
		}
		
		int GetNearest(Vector3 p) {
			var distance = float.MaxValue;
			var nearest = 0;
			for (int i = 0; vertices.Count > i; i++) {
				var d = Vector3.Distance(p, vertices[i]);
				if (d < distance) {
					distance = d;
					nearest = i;
				}
			}
			return nearest;
		}
		
		int GetFarthest(Vector3 p) {
			var distance = float.MinValue;
			var farthest = 0;
			for (int i = 0; vertices.Count > i; i++) {
				var d = Vector3.Distance(p, vertices[i]);
				if (d > distance) {
					distance = d;
					farthest = i;
				}
			}
			return farthest;
		}
		
		void CopyFeature(GameObject target) {
			target.transform.position = transform.position;
			target.transform.rotation = transform.rotation;
			target.rigidbody.velocity = rigidbody.velocity;
		}
		
	}

}
