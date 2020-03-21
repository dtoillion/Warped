using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
  AudioSource audioSrc;
  public AudioClip[] audioClips;
  public static SoundEffectsManager soundControl;

  void Start()
  {
    soundControl = this;
    audioSrc = GetComponent<AudioSource>();
  }

  public void GameOverSound(){
    audioSrc.clip = audioClips[0];
    audioSrc.PlayOneShot(audioSrc.clip, 1f);
  }

}
