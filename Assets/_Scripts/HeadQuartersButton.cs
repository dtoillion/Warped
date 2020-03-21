using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadQuartersButton : MonoBehaviour
{
  public GameObject HeadquartersMenu;
  private bool MenuOpened = false;

  void OnMouseDown() {
    if(MenuOpened) {
      HeadquartersMenu.SetActive(false);
      MenuOpened = false;
    } else {
      HeadquartersMenu.SetActive(true);
      MenuOpened = true;
    }

  }
  void OnMouseOver() {

  }

}
