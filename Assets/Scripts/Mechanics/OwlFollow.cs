using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlFollow : MonoBehaviour {

    public bool follow = false;
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    // Use this for initialization
    void Start () {
        target = GameObject.Find("Panda").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (follow)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target);
        }
    }

    public void FollowPlayer()
    {
        follow = true;
    }
}
