using UnityEngine;
using System.Collections;

namespace Dynagon.Test {

	public static class Assert {

		public static void Equal(object actual, object expected) {
			if (!actual.Equals(expected)) {
				var message = "actual: " + actual.ToString() + " , expected: " + expected.ToString();
				Debug.LogError(message);
			}
		}

	}

	public abstract class TestSuite {

		public abstract void Run();

	}

}
