using UnityEngine;
using System.Collections;

public class RoboControl : MonoBehaviour {

	public bool Land;
	public float landAccel;
	public float landSteer;
	public float jumpForce;
	public float Stability;
	public float StabilizeSpeed;

	public float updrift;
	public float airBrake;
	public float rollSpeed;
	public float pitchSpeed;


	private bool justswitched;
	public float launchspeed;

	public float speed;

	public GameObject Wings;
	public GameObject Wingstimer;

	private float deployTime;

	public float WingsLastTime;


	// Use this for initialization
	void Start () {
	
	}
	
	
	void Stabilize() {
		var rigid = GetComponent<Rigidbody> ();
		Vector3 predictedUp = Quaternion.AngleAxis(rigid.angularVelocity.magnitude * Mathf.Rad2Deg * Stability / StabilizeSpeed, rigid.angularVelocity) * transform.up;
		Vector3 torqueVector = Vector3.Cross(predictedUp, Vector3.up);
		rigid.AddTorque(torqueVector * StabilizeSpeed * StabilizeSpeed);
	}

	// Update is called once per frame
	void Update () {
		var h = Input.GetAxis ("Horizontal");
		var v = Input.GetAxis ("Vertical");
		var rig = GetComponent<Rigidbody> ();
		
		speed = rig.velocity.magnitude;
		if (Land) {
			Wings.SetActive(false);
			Wingstimer.SetActive(false);
			rig.useGravity = true;
			if (v > 0.1f || v < -0.1f) {
					rig.AddForce (v * landAccel * transform.forward, ForceMode.Acceleration);
			}
			if (h < 0.1f || h > -0.1f) {
					transform.RotateAround (transform.position, Vector3.up, h * landSteer);
			}
			if (Input.GetButtonDown ("Jump")) {
				
				if (speed > launchspeed) {
					rig.AddForce (rig.velocity.magnitude * jumpForce * Vector3.up, ForceMode.Impulse);
					Land = false;
					deployTime = Time.time;
				}
			}
			Stabilize ();
			justswitched = true;
		} else {
			//rig.velocity = new Vector3(rig.velocity.x * airBrake, rig.velocity.y, rig.velocity.z * airBrake);
			/*
			while (rig.velocity.magnitude > 8) {
				rig.velocity = rig.velocity * 0.9f;
			}
			var up = Vector3.up * speed * updrift;
			while (up.magnitude > 8) {
				up = up * 0.9f;
			}
			rig.AddForce(up,ForceMode.Force);
			
			rig.AddForce(transform.forward * updrift,ForceMode.Acceleration);*/
			if (justswitched) {
				Wings.SetActive(true);
				Wingstimer.SetActive(true);
				rig.useGravity = false;
				rig.velocity = Vector3.zero;
				//transform.RotateAround(transform.position, transform.right, 0);
				transform.position = transform.position + Vector3.up*5;
				justswitched = false;
				rig.AddForce(transform.forward * speed * updrift,ForceMode.Impulse);
			} else {
				rig.velocity = Vector3.zero;
				rig.velocity = transform.forward * 5;
			}

			Wingstimer.GetComponentInChildren<UnityEngine.UI.Text>().text = (Time.time - (deployTime + WingsLastTime)).ToString ("F3");

			//rig.AddForce(transform.forward);
			//var down = (-Vector3.up * (9.8f - updrift * speed)) ;
			//rig.AddForce(down,ForceMode.Force);


			bool moved = false;
			if (v > 0.1f || v < -0.1f) {
				moved = true;
				transform.RotateAround (transform.position, transform.right, v * pitchSpeed);
			}
			if (h < 0.1f || h > -0.1f) {
				moved = true;
				transform.RotateAround (transform.position, transform.forward, -h * rollSpeed);
			}
			if (!moved) {
				Stabilize ();
			}
			if (Input.GetButtonDown ("Jump")) {
					Land = true;
			}
			if ((deployTime + WingsLastTime) < Time.time) {
				Land = true;
			}
		}
	}
}
