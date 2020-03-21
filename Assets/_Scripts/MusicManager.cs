using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] musicbg;
	AudioSource backgroundMusic;
	private int i;

	void Awake() {
		backgroundMusic = GetComponent <AudioSource> ();
	}

	void Start() {
		if (musicbg.Length > 0) {
		  i = UnityEngine.Random.Range(0,musicbg.Length);
		  StartCoroutine("Playlist");
		}
	}

	IEnumerator Playlist() {
		while(true) {
			yield return new WaitForSeconds(1.0f);
			if(!backgroundMusic.isPlaying) {
				if(i != (musicbg.Length -1)) {
					i++;
					backgroundMusic.clip = musicbg[i];
					backgroundMusic.Play();
				}	else {
					i=0;
					backgroundMusic.clip= musicbg[i];
					backgroundMusic.Play();
				}
			}
		}
	}

}
