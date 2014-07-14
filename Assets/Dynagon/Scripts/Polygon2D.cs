using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dynagon {

	public class Polygon2D : Polygon {

		public Polygon2D(GameObject gameObject, List<Vector3> vertices) : base(gameObject, vertices) {}

		protected override void OptimizeIndexes() {
			foreach (var i in Enumerable.Range(0, indexes.Count/3).Select(i => i * 3)) {
				var center = GetCenterOfTriangle(i);
				var bottom = new Vector3(center.x, center.y, float.MinValue);
				if (Vector3.Dot(GetNormalOfTriangle(i), center - bottom) < 0) {
					ReverseSurface(i);
				}
			}
		}
		
	}

}
