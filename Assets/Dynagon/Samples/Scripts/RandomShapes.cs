using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Dynagon;

namespace Dynagon.Sample {

	public class RandomShapes : MonoBehaviour {

		public float interval = 0.5f;

		float timer = 0f;

		Polygon CreateFlatPyramid() {
			var size = 20f;
			var eulerX = (Mathf.PI / 2 + Mathf.Asin(1f/3f)) * Mathf.Rad2Deg;
			var eulerY = 90;
			var vertices = new List<Vector3>() {
				Vector3.up * size * 0.1f,
				Quaternion.Euler(eulerX, 0, 0) * Vector3.up * size,
				Quaternion.Euler(eulerX, eulerY * 1, 0) * Vector3.up * size,
				Quaternion.Euler(eulerX, eulerY * 2, 0) * Vector3.up * size,
				Quaternion.Euler(eulerX, eulerY * 3, 0) * Vector3.up * size
			};
			return Factory.Create("Pyramid", vertices);
		}

		Polygon CreateSphericalPolygon(int numVertices = 15, float radius = 1f) {
			var vertices = new List<Vector3>();
			var center = new Vector3(0, 0, 0);
			for (int i = 0; numVertices > i; i++) {
				vertices.Add(Random.onUnitSphere * radius + center);
			}
			return Factory.Create("RandomShape", vertices);
		}

		void Create() {
			var polygon = CreateSphericalPolygon().Rigidize();
			polygon.gameObject.transform.position = new Vector3(0, 8, 0) + Random.insideUnitSphere;
		}

		void Start() {
			CreateFlatPyramid();
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
