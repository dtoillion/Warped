using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEntrance : MonoBehaviour
{
  public Animator anim;
  public GameObject FrameToExit;
  public GameObject FrameToEnter;
  private bool DoorIsOpen = true;

  void OnTriggerEnter2D(Collider2D collision) {
    if(collision.gameObject.tag == "Player") {
      if(anim.GetBool("DoorOpen")) {
        anim.SetBool("DoorOpen", false);
        DoorIsOpen = false;
      } else {
        anim.SetBool("DoorOpen", true);
        DoorIsOpen = true;
      }
    }
  }
  
  void OnTriggerExit2D(Collider2D collision) {
    if(collision.gameObject.tag == "Player") {
      anim.SetBool("DoorOpen", false);
      DoorIsOpen = false;
    }
  }

  void Update() {
    if(DoorIsOpen) {
      if(Input.GetKeyUp(KeyCode.E)) {
        DoorIsOpen = false;
        FrameToExit.SetActive(false);
        FrameToEnter.SetActive(true);
      }
    }
  }

}
