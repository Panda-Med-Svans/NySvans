using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator anim;
    public bool isRunning = false;

    //anim.SetBool("isGrounded", player.isGrounded);
    //anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("isRunning");
            isRunning = true;
        }
        if(Input.GetKeyDown(KeyCode.Space) && isRunning == true)
        {
            anim.SetBool("isGrounded", false);
            anim.SetTrigger("isJumping");
            Invoke("AnimJump", 2f);
        }
    }

    void AnimJump()
    {
        anim.SetBool("isGrounded", true);
    }


}
