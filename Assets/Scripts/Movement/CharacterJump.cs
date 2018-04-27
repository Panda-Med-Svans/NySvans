using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour {



  //  private bool isGrounded = false;
  //  private bool hasJumped = false;
  //  private bool canDoubleJump = false;
  //  public float delayBeforeDoubleJump;
  //  public int doubleJumpCount;
  //  public int numberOfDoubleJumps = 1;


  //  public float jumpSpeed = 8.0f;
  //  public float gravity = 20.0f;
  //  private Vector2 moveDirection = Vector2.zero;
  //  private CharacterController player;

  //  public float startSpeed = 6f;
  //  private float currentSpeed;






  //  void Start()
  //  {
  //      currentSpeed = startSpeed;
  //      player = GetComponent<CharacterController>();
  //      //doubleJumpCount = numberOfDoubleJumps;
  //  }

  //  void FixedUpdate()
  //  {
  //      Debug.Log(doubleJumpCount);
  //      if (Input.GetButtonDown("Jump") && doubleJumpCount <= numberOfDoubleJumps)
  //      {
  //          moveDirection.y = jumpSpeed;
  //          doubleJumpCount++;
  //      }
  //      else
  //      {
  //          moveDirection.y -= gravity * Time.deltaTime;
  //      }
  //      player.Move(moveDirection * Time.deltaTime);
  //  }

  

  //  void OnCollisionEnter(Collision collision)
  //  {
  //      Debug.Log("hit the ground");
  //      if (collision.gameObject.tag == "Ground")
  //      {
  //          Debug.Log("and it is the ground");
  //          isGrounded = true;
  //          hasJumped = false;
  //          canDoubleJump = false;
  //          moveDirection.y = 0;
  //          doubleJumpCount = 0;
  //      }
  //      if (collision.gameObject.tag == "Bad")
  //      {
  //          //Bad();
  //      }
  //  }


  ////void FixedUpdate()
  //  //{
  //  //    //Debug.Log("isGrounded is " + isGrounded + " & canDoubleJump is " + canDoubleJump);
  //  //    if (Input.GetButtonDown("Jump"))
  //  //    {
  //  //        Debug.Log("pressed Jump");
  //  //        //moveDirection.x = currentSpeed;
  //  //        if (isGrounded)
  //  //        {
  //  //            Jump();
  //  //        }
  //  //        if (canDoubleJump)
  //  //        {
  //  //            Jump();
  //  //        }
  //  //        moveDirection.x = currentSpeed;
  //  //    }
  //  //    else
  //  //    {
  //  //        moveDirection.y -= gravity * Time.deltaTime;
  //  //    }
  //  //}
  //  //void Bad()
  //  //{
  //  //    //TODO something when you touch bad
  //  //}

  //  //void Jump()
  //  //{
  //  //    if (isGrounded)
  //  //    {
  //  //        hasJumped = true;
  //  //        isGrounded = false;
  //  //        moveDirection.y = jumpSpeed;
  //  //        Invoke("EnableDoubleJump", delayBeforeDoubleJump);
  //  //        //TODO: link animation, sound etc
  //  //    }
  //  //    if (canDoubleJump)
  //  //    {
  //  //        canDoubleJump = false;
  //  //        moveDirection.y = jumpSpeed;
  //  //        //TODO: link animation, sound etc
  //  //    }
  //  //}
  //  //void EnableDoubleJump()
  //  //{
  //  //    canDoubleJump = true;
  //  //}
}
