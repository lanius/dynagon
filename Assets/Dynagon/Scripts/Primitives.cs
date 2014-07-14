using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dynagon {
	
	internal abstract class Triangular {
		public Vector3[] p;
		
		public bool ShareVertex(Triangular t) {
			foreach (var v in p) {
				foreach (var tv in t.p) {
					if (v.Equals(tv)) {
						return true;
					}
				}
			}
			return false;
		}

		public override bool Equals(object obj) {
			var t = (Triangular)obj;
			foreach (var i in Enumerable.Range(0, p.Length)) {
				if (!p[i].Equals(t.p[i])) {
					return false;
				}
			}
			return true;
		}

		public override int GetHashCode() {
			// todo: improve
			return (int)p[0].x ^ (int)p[1].y ^ (int)p[2].z;
		}
	}
	
	internal class Triangle : Triangular {

		public Triangle(Vector3 p0, Vector3 p1, Vector3 p2) {
			p = new Vector3[] {p0, p1, p2};
			Array.Sort(p, Function.CompareVector3);
		}
	}

	internal class Tetrahedron : Triangular {

		public Tetrahedron(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3) {
			p = new Vector3[] {p0, p1, p2, p3};
			Array.Sort(p, Function.CompareVector3);
		}
	}

	internal abstract class Spherical {
		public readonly Vector3 center;
		public readonly float radius;
		
		public Spherical(Vector3 center, float radius) {
			this.center = center;
			this.radius = radius;
		}
	}

	internal class Circle : Spherical {
		public Circle(Vector3 center, float radius) : base(center, radius) {}
	}

	internal class Sphere : Spherical {
		public Sphere(Vector3 center, float radius) : base(center, radius) {}
	}

}
