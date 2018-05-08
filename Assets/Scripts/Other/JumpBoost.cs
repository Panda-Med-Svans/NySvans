using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour {

    public CharacterMovement boost;
    public string playerName;

    void Start()
    {

        boost = GameObject.Find(playerName).GetComponent<CharacterMovement>();
        //boost = GameObject.Find("Player").GetComponent<CharacterMovement>();
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            boost.BoostJump();
        }
    }



}
