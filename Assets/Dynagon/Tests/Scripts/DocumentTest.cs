using UnityEngine;
using System.Collections.Generic;
using Dynagon;

namespace Dynagon.Test {

	public class DocumentTest : TestSuite {
		
		private void TestExampleOnDocument() {
			var vertices = new List<Vector3>() {
				new Vector3(0f, 1f, 0f),
				new Vector3(0f, -0.3f, 0.9f),
				new Vector3(0.8f, -0.3f, -0.5f),
				new Vector3(-0.8f, -0.3f, -0.5f)
			};

			Factory.Create(vertices);
			
			var triangles = Triangulator3D.Triangulate(vertices);
			new Polygon3D(new GameObject(), triangles).Build();
		}
		
		public override void Run() {
			TestExampleOnDocument();
		}
		
	}

}
