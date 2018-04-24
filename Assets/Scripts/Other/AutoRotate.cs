using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour {

    public GameObject target;
    public float rotationX;
    public float rotationY;
    public float rotationZ;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        target.transform.Rotate(new Vector3(rotationX, rotationY, rotationZ) * Time.deltaTime);
    }
}
