using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
  public GameObject FadeOut;
  public GameObject StartText;
  public AudioSource AmbientSound;
  public AudioSource StartSound;
  public float FadeOutTime;
  private bool GameStarted = false;

  void Update() {
    
    if (Input.GetKey("escape")) {
      Application.Quit();
    }

    if (Input.GetKey("return") && (!GameStarted)) {
      StartCoroutine("StartGame");
    }
  }

  public void ExitGame() {
    Application.Quit();
  }

  IEnumerator StartGame() {
    GameStarted = true;
    StartText.SetActive(false);
    StartSound.Play();
    AmbientSound.Stop();
    FadeOut.SetActive(true);
    yield return new WaitForSeconds(FadeOutTime);
    SceneManager.LoadScene("Stage01");
    StopCoroutine("StartGame");
  }
}
