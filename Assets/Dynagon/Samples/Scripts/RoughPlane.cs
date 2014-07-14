using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Dynagon;

namespace Dynagon.Sample {

	public class RoughPlane : MonoBehaviour {

		public float tileSize = 5f;
		public int numTiles = 10;
		public float interval = 2f;

		Polygon polygon;
		float timer = 0f;

		Polygon CreateRoughPlane(float tileSize = 5f, int numTiles = 10) {
			var half = (tileSize * numTiles) / 2;
			var offset = new Vector3(-half, -half, 0f);
			var vertices = new List<Vector3>();
			foreach (var i in Enumerable.Range(0, numTiles)) {
				foreach (var j in Enumerable.Range(0, numTiles)) {
					var noise = Random.insideUnitSphere * tileSize / 2;
					vertices.Add(offset + new Vector3(tileSize * i + noise.x, tileSize * j + noise.y, noise.z));
				}
			}
			var polygon = new Polygon2D(
				new GameObject("Rough Plane"),
				Triangulator2D.Triangulate(vertices)
				).Build();
			polygon.gameObject.transform.Rotate(new Vector3(-90, 0, 0));
			return polygon;
		}

		void Create() {
			if (polygon != null) {
				Destroy(polygon.gameObject);
			}
			polygon = CreateRoughPlane(tileSize, numTiles);
		}

		void Update() {
			timer += Time.deltaTime;
			if (timer > interval) {
				timer = 0f;
				Create();
			}
		}

	}

}
