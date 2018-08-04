using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour {

	public GameObject[] videos;
	private VideoPlayer videoPlayer = new VideoPlayer();

	void Start(){
		videoPlayer = this.GetComponent<VideoPlayer> ();
	}
		
	public void OnVideoClick(){
		foreach (GameObject video in videos) {
			video.GetComponent<VideoPlayer>().Stop();
		}
		if (videoPlayer.isPlaying) {
			videoPlayer.Stop ();
		} else {
			videoPlayer.Play ();
		}
	}
}
