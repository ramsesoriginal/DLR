using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Cancel"))
			ExitGame ();
	}

	public void LoadGame() {
		Application.LoadLevel("Game");
	}
	
	public void ExitGame() {
		if (Application.loadedLevelName == "Main") {
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit ();
#endif
		} else {
			Application.LoadLevel ("Main");
		}
	}

}
