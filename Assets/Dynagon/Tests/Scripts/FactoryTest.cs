using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Dynagon.Test {
	
	public class FactoryTest : TestSuite {

		private void TestCreate2D() {
			var polygon = Factory.Create(new List<Vector2>() {
				new Vector2(0, 0),
				new Vector2(0, 1),
				new Vector2(1, 0),
				new Vector2(1, 1),
			});
			Assert.Equal(polygon.vertices.Count / 3, 2);
		}

		private void TestCreate3D() {
			var polygon = Factory.Create(new List<Vector3>() {
				new Vector3(0, 0, 0),
				new Vector3(0, 1, 0),
				new Vector3(1, 0, 0),
				new Vector3(1, 1, 0),
				new Vector3(0, 0, 1),
				new Vector3(0, 1, 1),
				new Vector3(1, 0, 1),
				new Vector3(1, 1, 1),
			});
			Assert.Equal(polygon.vertices.Count / 3, 18);
		}
		
		public override void Run() {
			TestCreate2D();
			TestCreate3D();
		}
		
	}
}
