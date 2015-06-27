using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {

	public GameObject winscreen;
	public GameObject lostScreen;

	// Use this for initialization
	void Start () {
		//winscreen = GameObject.FindGameObjectWithTag ("WinScreen");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			Time.timeScale = 0.05f;
			winscreen.SetActive (true);
		}
	}

}
