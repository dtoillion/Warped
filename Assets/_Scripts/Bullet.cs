using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  private Rigidbody2D rb;
  public float BulletSpeed;

  void Start() {
    rb = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate() {
    rb.AddForce(transform.right * BulletSpeed);
  }

  void OnCollisionEnter2D(Collision2D collision) {
    Destroy(gameObject);

  }

}
