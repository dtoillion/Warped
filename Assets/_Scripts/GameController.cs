using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  public static GameController controller;

  void Update() {
    
    if (Input.GetKey("escape")) {
      Application.Quit();
    }

  }
  public void ExitGame() {
    Application.Quit();
  }

}
