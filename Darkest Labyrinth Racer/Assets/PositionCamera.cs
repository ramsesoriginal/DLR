using UnityEngine;
using System.Collections;

public class PositionCamera : MonoBehaviour {

	public Transform player;
	public float followSpeed;
	public float flyFollow;

	private RoboControl control;

	// Use this for initialization
	void Start () {
		control = player.GetComponent<RoboControl> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (control.Land) {
			transform.position = Vector3.Lerp (transform.position, player.position + new Vector3 (0, 15f, 0) - player.forward * 12f, followSpeed);
			transform.LookAt (player.position);
		} else {
			transform.position = Vector3.Lerp (transform.position, player.position + player.up * 3f - player.forward * 12f, flyFollow);
			//transform.LookAt (player.position + player.up);
			transform.rotation = player.rotation;
		}
	}
}
