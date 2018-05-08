using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    #region Character Basics

    public float runSpeed = 6f;
    [Range(0.1f, 2f)][Tooltip("Lower is faster")]
    public float accelrationRate;
    [HideInInspector]
    public float currentSpeed;

    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector2 moveDirection = Vector2.zero;
    private CharacterController player;

    [Tooltip("För att starta utan att behöva klicka på menyer")]
    public bool autoStart;
    public static bool startRunning = false;
    

    [Space]

    #endregion

    #region Animations
    [HideInInspector]
    public Animator anim;
    private bool hasJumped = false;

    #endregion

    #region Jump
    
    private bool canDoubleJump = false;
    [Range(0.1f, 0.8f)]
    public float delayBeforeDoubleJump;
    [Range(0.1f, 0.5f)]
    public float deadzone = 0.2f;

    public float jumpBoost;

    #endregion





    #region Start Method

    void Start()
    {
        if(autoStart)
        {
            startRunning = true;
        }
        anim = GetComponent<Animator>();
        player = GetComponent<CharacterController>();
    }

    #endregion

    #region Update

    void FixedUpdate()
    {

        if (IsGrounded())
        {
            moveDirection.y = 0;
            canDoubleJump = false;
            if (Input.GetButton("Jump"))
            {
                Jump();
            }
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        if (Input.GetButton("Jump"))
        {
            Jump();
        }
        

        #region Start Running

        if (!startRunning)
        {
            moveDirection.x = 0;
        }
        else
        {
            anim.SetTrigger("isRunning");
            moveDirection.x = currentSpeed;
        }

        #endregion

        if (currentSpeed < runSpeed && startRunning)
        {
            currentSpeed += Time.deltaTime / accelrationRate;
        }
        

        player.Move(moveDirection * Time.deltaTime);

        #region placeholder Tilt speed
        //    //Debug.Log(currentSpeed);
        //    ////placeholder for tilt speed, verkar vara enklare att göra än vad detta är.
        //    //if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        //    //{
        //    //    if (currentSpeed <= maxSpeed)
        //    //    {
        //    //        currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, (smoothTime * Time.deltaTime));
        //    //    }
        //    //}
        //    //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        //    //{
        //    //    if (minSpeed <= currentSpeed)
        //    //    {
        //    //        currentSpeed = Mathf.Lerp(currentSpeed, minSpeed, (smoothTime * Time.deltaTime));
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    currentSpeed = Mathf.Lerp(currentSpeed, startSpeed, (smoothTime * Time.deltaTime));
        //}
        #endregion

    }

    #endregion

    #region Jump method

    public void Jump()
    {
        if (player.isGrounded)
        {
            
            moveDirection.y = jumpSpeed;
            hasJumped = true;
            Invoke("EnableDoubleJump", delayBeforeDoubleJump);
            //jumpsound.Play();
            anim.SetTrigger("isJumping");
            //TODO: link animation, sound etc
        }
        if (canDoubleJump)
        {
            canDoubleJump = false;
            moveDirection.y = jumpSpeed;
            //jumpsound.Play();
            anim.SetTrigger("isDoubleJumping");
            //TODO: link animation, sound etc
        }
        if (!player.isGrounded && !hasJumped) //Ett hopp medans man faller
        {
            hasJumped = true;
            moveDirection.y = jumpSpeed;
        }
    }
    void EnableDoubleJump()
    {
        canDoubleJump = true;
    }

    #endregion

    #region ShroomBoost

    public void BoostJump()
    {
        moveDirection.y = jumpSpeed * jumpBoost;
        //trigger för hopp animation
    }

    #endregion

    #region Grounded

    bool IsGrounded()
    {
        if (player.isGrounded)
        {
            anim.SetBool("isGrounded", true);
            hasJumped = false;
            return true;
        }
        

        Vector3 bottom = player.transform.position - new Vector3(0, player.height / 2, 0);

        RaycastHit hit;
        if(Physics.Raycast(bottom, new Vector3(0,-1, 0), out hit, deadzone))
        {
            player.Move(new Vector3(0, -hit.distance, 0));
            //Debug.Log("True. Ray");
            return true;
        }
        //anim.SetBool("isGrounded", false);
        return false;
    }

    #endregion

}

#region Single Jump //Unused
//void FixedUpdate()
//{
//    if (player.isGrounded)
//    {
//        moveDirection.y = 0;
//        if (Input.GetButton("Jump"))
//        {
//            moveDirection.y = jumpSpeed;
//        }
//    }
//    else
//    {
//        moveDirection.y -= gravity * Time.deltaTime;
//    }
//    moveDirection.x = currentSpeed;
//    player.Move(moveDirection * Time.deltaTime);
//}

#endregion
