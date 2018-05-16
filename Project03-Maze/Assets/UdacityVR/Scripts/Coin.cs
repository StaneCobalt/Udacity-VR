using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{
	//Create a reference to the CoinPoofPrefab
	public Transform poof;
	public AudioSource audioSource;

	public GameObject self;

    public void OnCoinClicked() {
		// Make sure the poof animates vertically
		Debug.Log("Coin Clicked");
		Vector3 pos = this.transform.position;
		Instantiate(poof, pos, Quaternion.Euler(-90.0f,0,0));
		audioSource.GetComponent<AudioSource>();
		audioSource.Play();
		Destroy(self);
		Debug.Log("Coin Collected");
    }

}
