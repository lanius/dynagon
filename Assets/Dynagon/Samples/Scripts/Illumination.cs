using UnityEngine;
using System.Collections;

namespace Dynagon.Sample {

	public class Illumination : MonoBehaviour {

		public Color color = new Color(0.3f, 0.4f, 0.85f);
		public float intensity = 1f;

		void Start () {
			light.color = color;
			light.intensity = intensity;
		}

	}

}
