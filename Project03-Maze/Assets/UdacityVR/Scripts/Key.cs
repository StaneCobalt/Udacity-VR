using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
	//Create a reference to the KeyPoofPrefab and Door
	public Transform keyPoof;
	private bool keyCollected;
	public Door door;
	public AudioClip audioClip;

	private void Awake()
	{
		keyCollected = false;
	}

	public void OnKeyClicked()
	{
		Vector3 pos = this.transform.position;
		keyPoof.GetComponent<AudioSource>().clip = audioClip;
		Instantiate(keyPoof, pos, Quaternion.Euler(-90.0f,0,0));
		door.Unlock();
		keyCollected = true;
		Destroy(gameObject);
		Debug.Log("Key Picked Up");
    }

}
