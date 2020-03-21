using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpedCharacterController : MonoBehaviour {
  private Animator anim;
  private Rigidbody2D rb;
  private SpriteRenderer sr;
  
  public float speed;
  public float jumpForce;
  public float jumpTime;
  
  public Transform groundCheck;
  public float checkRadius;
  public LayerMask WhatIsGround;
  
  private float moveInput;
  private bool facingRight = true;
  private float jumpTimeCounter;
  private bool isJumping;
  private bool isGrounded;

  public GameObject BulletLeft;
  public GameObject BulletRight;
  public GameObject GunPosition;

  void Start() {
    anim = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
    sr = GetComponent<SpriteRenderer>();
  }

  void FixedUpdate() {
    
    moveInput = Input.GetAxisRaw("Horizontal");
    rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    
    if(!facingRight && moveInput > 0) {
      FlipPlayer();
    } else if(facingRight && moveInput < 0) {
      FlipPlayer();        
    }
  }

  void Update() {
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatIsGround);

    if(isGrounded) {
      anim.SetBool("isJumping", false);
    } else {
      anim.SetBool("isJumping", true);
    }

    if(moveInput == 0) {
      anim.SetBool("isRunning", false);
    } else {
      anim.SetBool("isRunning", true );
    }
    
    if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
      isJumping = true;
      anim.SetTrigger("takeOff");
      jumpTimeCounter = jumpTime;
      rb.velocity = Vector2.up * jumpForce;
    }

    if(Input.GetKey(KeyCode.Space) && isJumping) {
      if(jumpTimeCounter > 0) {
        rb.velocity = Vector2.up * jumpForce;
        jumpTimeCounter -= Time.deltaTime;
      } else {
        isJumping = false;
      }
    }

    if(Input.GetKeyUp(KeyCode.Space)) {
      isJumping = false;
    }

    if(Input.GetKeyDown(KeyCode.Return) && isGrounded) {
      Debug.Log("Shoot");
      if(facingRight)
        Instantiate(BulletRight, GunPosition.transform.position, Quaternion.identity);
      else
        Instantiate(BulletLeft, GunPosition.transform.position, Quaternion.identity);
    }

  }

  void FlipPlayer () {
    facingRight = !facingRight;
    transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
  }

}
