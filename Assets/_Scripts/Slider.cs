using System.Collections;
using UnityEngine;

public class Slider : MonoBehaviour {

  public float Speed;
  public float WaitTime;

  private Vector3 PositionOne;
  private Vector3 PositionTwo;

  public float XOne;
  public float XTwo;

  public float YOne;
  public float YTwo;

  public float ZOne;
  public float ZTwo;

  void Start() {
    PositionOne = new Vector3(transform.position.x + XOne, transform.position.y + YOne, transform.position.z + ZOne);
    PositionTwo = new Vector3(transform.position.x + XTwo, transform.position.y + YTwo, transform.position.z + ZTwo);
  }

  void Update() {
    transform.position = Vector3.Lerp (PositionOne, PositionTwo, Mathf.PingPong(Time.time * Speed, WaitTime));
  }

}