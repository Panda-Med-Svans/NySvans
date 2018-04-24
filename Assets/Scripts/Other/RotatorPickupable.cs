using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorPickupable : MonoBehaviour
{

	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(new Vector3(15, 84, 23) * Time.deltaTime);
	}
}
