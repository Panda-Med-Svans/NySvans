using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryTrigger : MonoBehaviour {

    public Animator anim;
    public string targetAnimation;

	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();
		//get component in child of this gameobject of type animator
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            anim.SetTrigger(targetAnimation);
            //does something
        }
    }
}
