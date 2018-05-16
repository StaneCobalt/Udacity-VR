using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
	//Create a reference to the KeyPoofPrefab and Door
	public Transform keyPoof;
	private bool keyCollected;

	private GameObject door;
	public GameObject self;

	private void Awake()
	{
		keyCollected = false;
		door = GameObject.FindGameObjectWithTag("Door");
	}

	void Update()
	{
		//Not required, but for fun why not try adding a Key Floating Animation here :)
	}

	public void OnKeyClicked()
	{
		// Instatiate the KeyPoof Prefab where this key is located
		Vector3 pos = this.transform.position;
		if (transform.position.y < 0) pos.y = 0;
		// Make sure the poof animates vertically
		Instantiate(keyPoof, pos, Quaternion.Euler(-90.0f,0,0));
		door.GetComponent<Door>().Unlock();
		// Set the Key Collected Variable to true
		keyCollected = true;
		// Destroy the key. Check the Unity documentation on how to use Destroy
		Destroy(self);
		Debug.Log("Key Picked Up");
    }

}
