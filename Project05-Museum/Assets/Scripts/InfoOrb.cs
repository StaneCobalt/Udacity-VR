using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoOrb : MonoBehaviour {
	private Vector3 pos = new Vector3 ();
	private Vector3 offset = new Vector3 ();

	private GameObject canvas;
	private GameObject player;

	private Vector3 minimize = new Vector3 (0.01f, 0.01f, 0.01f);
	private Vector3 normalize = new Vector3();

	private float amplitude = 0.25f;
	private float frequency = 0.75f;
	private float distance = 0.0f;
	private float rotationY = 0.0f;
	private float positionZ = 0.0f;

	// Use this for initialization
	void Start () {
		pos = transform.position;
		canvas = transform.GetChild(0).gameObject;
		player = GameObject.Find("GvrEditorEmulator");
		normalize = this.transform.localScale;
	}

	// Update is called once per frame
	void FixedUpdate () {
		// if the canvas isn't open, then float up and down
		if (!canvas.activeSelf) {
			offset = pos;
			offset.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
			transform.position = offset;
		}
	}

	void Update(){
		distance = Vector3.Distance(player.transform.position, this.transform.position);
		if (distance > 11.0f) {
			transform.localScale = minimize;
		} else {
			transform.localScale = normalize;
		}
		if (canvas.activeSelf) {
			// rotate the waypoint to face the player
			rotationY = player.transform.GetChild(0).eulerAngles.y;
			transform.eulerAngles = new Vector3(transform.eulerAngles.x,
				rotationY, transform.eulerAngles.z);

			// bring the canvas in front of the orb
			positionZ = (rotationY > 0) ? -1.0f : 1.0f;
			canvas.transform.localPosition = new Vector3 (0.0f, 0.0f, positionZ);
		}
	}

	public void Clicked(){
		// makes canvas active
		canvas.SetActive (true);

		// makes Plane, Text1, and Button1 active
		canvas.transform.GetChild(0).gameObject.SetActive(true);
		canvas.transform.GetChild(1).gameObject.SetActive(true);
		canvas.transform.GetChild(2).gameObject.SetActive(true);

		// makes Text2 and Button2 inactive
		if(transform.childCount > 3){
			canvas.transform.GetChild(3).gameObject.SetActive(false);
			canvas.transform.GetChild(4).gameObject.SetActive(false);
		}
	}

	public void btnClick1(){
		// hide Text1 and Button1
		canvas.transform.GetChild(1).gameObject.SetActive(false);
		canvas.transform.GetChild(2).gameObject.SetActive(false);

		if (canvas.transform.childCount > 3) {
			// makes Text2 and Button2 active
			canvas.transform.GetChild (3).gameObject.SetActive (true);
			canvas.transform.GetChild (4).gameObject.SetActive (true);
		} else {
			// Hide the whole canvas
			canvas.transform.GetChild(0).gameObject.SetActive(false);
			canvas.SetActive (false);
		}
	}

	public void btnClick2(){
		// Hide the whole canvas
		canvas.transform.GetChild(0).gameObject.SetActive(false);
		canvas.transform.GetChild(3).gameObject.SetActive(false);
		canvas.transform.GetChild(4).gameObject.SetActive(false);
		canvas.SetActive (false);
	}

}
