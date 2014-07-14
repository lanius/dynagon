using UnityEngine;
using System.Collections;

namespace Dynagon.Sample {

	public class Bottom : MonoBehaviour {

		void OnCollisionEnter (Collision col) {
			Destroy(col.gameObject);
		}

	}

}