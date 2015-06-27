using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {

	public GameObject winscreen;

	// Use this for initialization
	void Start () {
		//winscreen = GameObject.FindGameObjectWithTag ("WinScreen");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter() {
		Time.timeScale = 0.05f;
		winscreen.SetActive (true);
	}

}
