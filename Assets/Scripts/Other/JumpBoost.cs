using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour {

    public CharacterMovement boost;

    void Start()
    {
        boost = GameObject.Find("Player").GetComponent<CharacterMovement>();
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            boost.BoostJump();
        }
    }



}
