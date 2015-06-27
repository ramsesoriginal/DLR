using UnityEngine;
using System.Collections;

public class Predator : MonoBehaviour {

	public GameObject player;
	public float speed;
	public GameObject Goal;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		Goal = GameObject.FindGameObjectWithTag ("Goal");
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (player.transform.position);
		RaycastHit hitinfo;
		if (Physics.Raycast (transform.position, transform.forward, out hitinfo)) {
			if (hitinfo.collider.tag == "Player"){
				GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Force);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			
			Time.timeScale = 0.05f;
			Goal.GetComponent<Win>().lostScreen.SetActive (true);
		}
	}
}
