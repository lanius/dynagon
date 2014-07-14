using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {

	void LoadNextScene() {
		var next = Application.loadedLevel + 1;
		if(next >= Application.levelCount) {
			next = 0;
		}
		Application.LoadLevel(next);
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			LoadNextScene();
		}
	}

}
