using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{
	//Create a reference to the CoinPoofPrefab
	public Transform poof;
	public AudioClip audioClip;

    public void OnCoinClicked() {
		Debug.Log("Coin Collected");
		Vector3 pos = this.transform.position;
		poof.GetComponent<AudioSource>().clip = audioClip;
		Instantiate(poof, pos, Quaternion.Euler(-90.0f,0,0));
		Destroy(gameObject);
    }

}
