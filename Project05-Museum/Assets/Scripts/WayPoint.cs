using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour { 

	private GameObject player;

	private Vector3 size = new Vector3(1.0f, 1.0f, 1.0f);
	private Vector3 minimize = new Vector3 (0.0001f, 0.0001f, 0.0001f);
	private Vector3 normalize = new Vector3();

	private bool clicked;

	public float speed = 0.1f;
	private float distance = 0.0f;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("GvrEditorEmulator");
		normalize = this.transform.localScale;
		clicked = false;
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(player.transform.position, this.transform.position);
		if (clicked || distance > 21.0f) {
			transform.localScale = minimize;
		} else {
			transform.localScale = normalize;
		}
		if (distance < 1.0f) {
			clicked = false;
		}
		if (clicked) {
			iTween.MoveTo(player,
				iTween.Hash(
					"position", this.transform.position,
					"time", 1,
					"easetype", "linear"
			));
		}
	}

	public void OnEnter(){
		transform.localScale += size;
	}

	public void OnLeave(){
		transform.localScale -= size;
	}

	public void OnClick(){
		clicked = true;
	}

}
