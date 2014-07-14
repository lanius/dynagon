using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dynagon {

	public static class Factory {

		public static Polygon Create(GameObject gameObject, List<Vector2> vertices) {
			return new Polygon2D(
				gameObject,
				Triangulator2D.Triangulate(vertices.Select(v => (Vector3)v).ToList())
			).Build();
		}

		public static Polygon Create(string name, List<Vector2> vertices) {
			return Create(new GameObject(name), vertices);
		}

		public static Polygon Create(List<Vector2> vertices) {
			return Create(new GameObject(), vertices);
		}

		public static Polygon Create(GameObject gameObject, List<Vector3> vertices) {
			return new Polygon3D(
				gameObject,
				Triangulator3D.Triangulate(vertices)
			).Build();
		}

		public static Polygon Create(string name, List<Vector3> vertices) {
			return Create(new GameObject(name), vertices);
		}

		public static Polygon Create(List<Vector3> vertices) {
			return Create(new GameObject(), vertices);
		}

	}

}
