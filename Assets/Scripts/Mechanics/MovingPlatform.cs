using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public bool moving = false;
    private CharacterMovement charSpeed;

	// Use this for initialization
	void Start () {
        charSpeed = GameObject.Find("Player").GetComponent<CharacterMovement>();

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            moving = true;
            other.transform.SetParent(transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            moving = false;
            other.transform.SetParent(null);
        }
    }
  
    void FixedUpdate()
    {
        if (moving == true)
        {
            transform.Translate(Vector3.right * 4 * Time.deltaTime, Space.World);
            //charSpeed.currentSpeed = 0f;
        }
        else
        {
            //charSpeed.currentSpeed = 6f;
        }
    }
}
