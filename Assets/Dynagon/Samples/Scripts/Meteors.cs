using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Dynagon;

namespace Dynagon.Sample {

	public class Meteors : MonoBehaviour {

		public GameObject meteor;
		public GameObject spawnPoint;
		public float speed = 1f;
		public float interval = 0.5f;

		float timer = 0f;

		void Create() {
			var polygon = Instantiate(
				meteor,
				spawnPoint.transform.position,
				Quaternion.identity
				) as GameObject;
			polygon.rigidbody.velocity = (Vector3.zero - polygon.transform.position) * speed;
		}

		void Update() {
			timer += Time.deltaTime;
			if (timer > interval) {
				timer = 0f;
				Create();
			}
		}

	}

}
