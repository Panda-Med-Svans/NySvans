﻿using System.Collections;
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

    private bool hasJumped = false;
    [HideInInspector]
    public Animator anim;

    #endregion

    #region Jump

    private bool canDoubleJump = false;
    [Range(0.1f, 0.8f)]
    public float delayBeforeDoubleJump;
    [Range(0.05f, 0.5f)]
    public float deadzone = 0.2f;
    public float jumpBoost;
    [Space]

    #endregion

    #region Panda Sounds

    private AudioSource pandaSounds;
    public AudioClip[] idleSounds;
    [Range(1.0f, 20.0f)]
    public float delayToIdleSounds;
    public AudioClip[] jumpClip;
    public AudioClip[] landningClip;

    #endregion




    #region Start Method

    void Start()
    {
        if (autoStart)
        {
            startRunning = true;
        }
        pandaSounds = GetComponent<AudioSource>();
        anim = GetComponentInChildren<Animator>();
        player = GetComponent<CharacterController>();
        StartCoroutine(IdleSounds());


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
            StopCoroutine(IdleSounds());
            //anim.SetTrigger("isRunning"); //ändra till bool så man kan stänga av när man kommer i mål
            moveDirection.x = currentSpeed;
        }

        #endregion

        if (currentSpeed < runSpeed && startRunning)
        {
            currentSpeed += Time.deltaTime / accelrationRate;
        }



        player.Move(moveDirection * Time.deltaTime);
        anim.SetFloat("Speed", player.velocity.x);
        anim.SetFloat("falling", player.velocity.y);


    }

    #endregion

    #region Jump method

    public void Jump()
    {
        if (player.isGrounded)
        {

            moveDirection.y = jumpSpeed;
            anim.SetTrigger("isJumping");
            hasJumped = true;
            Invoke("EnableDoubleJump", delayBeforeDoubleJump);
            JumpSounds();
        }
        if (canDoubleJump)
        {
            canDoubleJump = false;
            moveDirection.y = jumpSpeed;
            anim.SetTrigger("isJumping");
            JumpSounds();
        }
        if (!player.isGrounded && !hasJumped) //Ett hopp medans man faller
        {
            hasJumped = true;
            moveDirection.y = jumpSpeed;
            anim.SetTrigger("isJumping");
            JumpSounds();
        }
    }
    void EnableDoubleJump()
    {
        canDoubleJump = true;
    }

    void JumpSounds()
    {
        pandaSounds.clip = jumpClip[Random.Range(0, jumpClip.Length)];
        pandaSounds.Play();
    }

    void LandSounds()
    {
        pandaSounds.clip = landningClip[Random.Range(0, landningClip.Length)];
        pandaSounds.Play();
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
            //landnings ljud
            //LandSounds();
            anim.SetBool("isGrounded", true);
            hasJumped = false;
            return true;
        }


        Vector3 bottom = player.transform.position - new Vector3(0, player.height / 2, 0);

        RaycastHit hit;
        if (Physics.Raycast(bottom, new Vector3(0, -1, 0), out hit, deadzone))
        {

            player.Move(new Vector3(0, -hit.distance, 0));
            hasJumped = false;
            return true;
        }
        anim.SetBool("isGrounded", false);
        return false;
    }

    #endregion

    #region Sounds

    IEnumerator IdleSounds()
    {
        while (!startRunning)
        {

            yield return new WaitForSeconds(delayToIdleSounds);
            //Debug.Log("Played a sound");
            if (!startRunning)
            {
                pandaSounds.clip = idleSounds[Random.Range(0, idleSounds.Length)]; //välj ljud från index 0, sen 1, sen 2, osv
                pandaSounds.Play();
            }
            else
                break;

        }
    }

    void /*IEnumerator*/ EndingSound()
    {
        //spelar upp ett random ljud 
        Debug.Log("");
        //yield return new WaitForSeconds(1f);
    }


    #endregion

}