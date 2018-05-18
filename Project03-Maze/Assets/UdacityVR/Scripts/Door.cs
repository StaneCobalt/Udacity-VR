using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	private bool locked { get; set; }
	private bool opening { get; set; }

	public AudioClip lockedSound;
	public AudioClip unlockedSound;
	//public AudioClip openSound;
	public AudioSource audioSource;

	public Animation doorOpen;

	private float killTime { get; set; }

	private void Awake()
	{
		locked = true;
		opening = false;
		killTime = 1.5f;
	}

	private void Update()
	{
		if (opening)
		{
			doorOpen["DoorOpen"].wrapMode = WrapMode.Once;
			doorOpen.Play(doorOpen.clip.name);
			Debug.Log("Door Opened");
			killTime -= Time.deltaTime;
		}
		if (killTime <= 0)
		{
			Destroy(gameObject);
		}
	}

	public void OnDoorClicked()
	{
		Debug.Log("Door Clicked");
		if (!locked && !opening)
		{
			Debug.Log("Door Unlocked");
			audioSource = GetComponent<AudioSource>();
			audioSource.clip = unlockedSound;
			audioSource.Play();
			opening = true;
		}
		else
		{
			Debug.Log("Door Locked");
			audioSource = GetComponent<AudioSource>();
			audioSource.clip = lockedSound;
			audioSource.Play();
		}
	}

	public void Unlock()
	{
		locked = false;
		doorOpen = GetComponent<Animation>();
		killTime = doorOpen.clip.length;
	}

}
