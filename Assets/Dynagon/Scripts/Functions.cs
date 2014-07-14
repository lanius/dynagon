using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Dynagon {

	internal static class Function {
		
		public static int CompareVector3(Vector3 p0, Vector3 p1) {
			if (p0.x > p1.x) {
				return 1;
			}
			else if (p0.x < p1.x) {
				return -1;
			}
			if (p0.y > p1.y) {
				return 1;
			}
			else if (p0.y < p1.y) {
				return -1;
			}
			if (p0.z > p1.z) {
				return 1;
			}
			else if (p0.z < p1.z) {
				return -1;
			}
			return 0;
		}
		
		public static List<Vector3> ConvertTrianglesToList(List<Triangle> triangles) {
			var list = new List<Vector3>();
			foreach (var t in triangles) {
				foreach (var p in t.p) {
					list.Add(p);
				}
			}
			return list;
		}
		
	}
	
}
