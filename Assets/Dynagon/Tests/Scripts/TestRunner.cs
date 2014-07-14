using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Dynagon.Test {

	public class TestRunner : MonoBehaviour {

		void Start () {
			var tests = new List<TestSuite>() {
				new FactoryTest(),
				new TriangulatorTest(),
				new DocumentTest()
			};
			foreach (var t in tests) {
				t.Run();
			}
			Debug.Log("All tests have finished.");
		}
	}

}
