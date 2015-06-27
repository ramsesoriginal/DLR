using UnityEngine;
using System.Collections;

public class TimeSinceLevelStart : MonoBehaviour {

	public UnityEngine.UI.Text timer;
	public GameObject winPanel;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!winPanel.activeSelf)
			timer.text = Time.timeSinceLevelLoad.ToString ("F3");
	}
}
