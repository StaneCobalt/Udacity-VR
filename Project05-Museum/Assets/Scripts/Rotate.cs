using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public float speed = 10.0f;

	// Update is called once per frame
	void Update () {
		this.transform.Rotate (Vector3.up * Time.deltaTime * speed, Space.World);
	}
}
