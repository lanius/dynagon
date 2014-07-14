using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Dynagon.Test {

	public class TriangulatorTest : TestSuite {

		private void TestTriangulate2D() {
			var vertices = Triangulator2D.Triangulate(new List<Vector3>() {
				new Vector3(0, 0),
				new Vector3(0, 1),
				new Vector3(1, 0),
				new Vector3(1, 1),
			});
			Assert.Equal(vertices.Count / 3, 2);
		}

		private void TestTriangulate3D() {
			var vertices = Triangulator3D.Triangulate(new List<Vector3>() {
				new Vector3(0, 0, 0),
				new Vector3(0, 1, 0),
				new Vector3(1, 0, 0),
				new Vector3(1, 1, 0),
				new Vector3(0, 0, 1),
				new Vector3(0, 1, 1),
				new Vector3(1, 0, 1),
				new Vector3(1, 1, 1),
			});
			Assert.Equal(vertices.Count / 3, 18);
		}
		
		public override void Run() {
			TestTriangulate2D();
			TestTriangulate3D();
		}

	}

}
