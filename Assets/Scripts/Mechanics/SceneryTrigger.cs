using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryTrigger : MonoBehaviour {

    [Tooltip("asd")]
    public Animator targetAnimator;
    [Tooltip("asd")]
    public string animationTrigger;

	// Use this for initialization
	void Start () {
        targetAnimator = GetComponentInChildren<Animator>();
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            targetAnimator.SetTrigger(animationTrigger);
        }
    }
}
