using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    

    #region Character Basics

    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector2 moveDirection = Vector2.zero;
    private CharacterController player;
    private bool startRunning = false;
    public KeyCode startKey = KeyCode.Q;


    #endregion

    #region Animations

    public Animator anim;
    public bool hasJumped = false;

    #endregion

    #region Jump

    //private bool hasJumped = false;
    private bool canDoubleJump = false;
    public float delayBeforeDoubleJump;
    public float deadzone = 0.2f;

    #endregion

    #region Tilt Controls + Character Speed

    public float startSpeed = 6f;
    private float currentSpeed;
    //public float minSpeedMultiplier;
    //private float minSpeed;
    //public float maxSpeedMultiplier;
    //private float maxSpeed;
    //public float smoothTime;
    //public something tiltAngle;

    #endregion



    #region Start Method

    void Start()
    {
        //minSpeed = startSpeed * minSpeedMultiplier;
        //maxSpeed = startSpeed * maxSpeedMultiplier;
        player = GetComponent<CharacterController>();
        currentSpeed = startSpeed;
        anim = GetComponent<Animator>();
    }

    #endregion

    #region Update

    void FixedUpdate()
    {

        if (IsGrounded())
        {
            moveDirection.y = 0;
            //anim.SetBool("isGrounded", player.isGrounded)
            //hasJumped = false;
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
            Debug.Log("Press "+ startKey + " to start!");
            moveDirection.x = 0;
            if (Input.GetKeyDown(startKey)) //ändra till menyklickS
            {
                startRunning = true;
            }
        }
        else
        {
            moveDirection.x = currentSpeed;
        }

        #endregion

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
            //anim.SetBool("hasJumped", true/false); 
            //TODO: link animation, sound etc
        }
        if (canDoubleJump)
        {
            canDoubleJump = false;
            moveDirection.y = jumpSpeed;
            //jumpsound.Play();
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
    
    #region Grounded

    bool IsGrounded()
    {
        if (player.isGrounded)
        {
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
