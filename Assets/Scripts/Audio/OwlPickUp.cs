using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlPickUp : MonoBehaviour
{
    private bool pickedUp = false;
    private ScoreTracker callOwl;
    private OwlCollection callCollectSound;
    private MusicAdvance owlAdvance;
    public bool owlTrummor, owlGitarr, owlBas, owlBanjo;
    [Space]
    public bool follow = false;
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void Start()
    {
        callOwl = FindObjectOfType<ScoreTracker>();
        callCollectSound = FindObjectOfType<OwlCollection>();
        owlAdvance = FindObjectOfType<MusicAdvance>();
        if(owlTrummor)
        {
            target = GameObject.Find("Panda").GetComponent<Transform>();
        }
        if (owlGitarr)
        {
            target = GameObject.Find("Owl(Drum)").GetComponent<Transform>();
        }
        if (owlBas)
        {
            target = GameObject.Find("Owl(Gitarr)").GetComponent<Transform>();
        }
        if (owlBanjo)
        {
            target = GameObject.Find("Owl(Base)").GetComponent<Transform>();
        }

        
    }
    

    
    void FixedUpdate()
    {
        if (follow)
        {
            Debug.Log("true");
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && pickedUp == false)
        {
            pickedUp = true;                
            callOwl.Owl();                  //Ger score
            callCollectSound.OwlCollect();  //spelar upp jingle
            FollowPlayer();
            //gameObject.SetActive(false);
            Debug.Log("Something activated");
            //Destroy(gameObject);            //dödar objektet
            if(owlTrummor)
            {
                owlAdvance.Trummor();
            }
            if (owlBas)
            {
                owlAdvance.Bas();
            }
            if (owlGitarr)
            {
                owlAdvance.Gitarr();
            }
            if(owlBanjo)
            {
                owlAdvance.Banjo();
            }
        }
    }
    public void FollowPlayer()
    {
        follow = true;
    }

}
