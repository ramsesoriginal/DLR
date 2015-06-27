using UnityEngine;
using System.Collections;

public class ResetLandControl : MonoBehaviour {

	public Transform player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		//Debug.Log ("Collision");
		player.GetComponent<RoboControl> ().Land = true;
		var y = player.eulerAngles.y;
		player.eulerAngles = new Vector3 (0, y, 0);
	}
}
