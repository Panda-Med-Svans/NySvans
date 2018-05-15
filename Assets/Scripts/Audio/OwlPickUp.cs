using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlPickUp : MonoBehaviour
{
    private bool pickedUp = false;
    private ScoreTracker callOwl;
    private OwlCollection callCollectSound;
    private MusicAdvance owlAdvance;
    public bool owlTrummor, owlGitarr, owlPiano, owlBas, owlBanjo, owlTrumpet, owlOrgel;
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
            target = GameObject.Find("Owl(Trum)").GetComponent<Transform>();
        }
        if (owlPiano)
        {
            target = GameObject.Find("Owl(Gitarr)").GetComponent<Transform>();
        }
        if (owlBas)
        {
            target = GameObject.Find("Panda").GetComponent<Transform>();
        }
        if (owlBanjo)
        {
            target = GameObject.Find("Owl(Bas)").GetComponent<Transform>();
        }
        if (owlTrumpet)
        {
            target = GameObject.Find("Owl(Banjo)").GetComponent<Transform>();
        }
        if (owlOrgel)
        {
            target = GameObject.Find("Owl(Piano)").GetComponent<Transform>();
        }

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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && pickedUp == false)
        {
            pickedUp = true;                
            callOwl.Owl();                  //Ger score
            callCollectSound.OwlCollect();  //spelar upp jingle
            FollowPlayer();
            //spela upp collect ljud
            //gameObject.SetActive(false);
            //Destroy(gameObject);            //dödar objektet

            if (owlTrummor)
            {
                owlAdvance.Trummor();
            }
            if (owlGitarr)
            {
                owlAdvance.Gitarr();
            }
            if (owlPiano)
            {
                owlAdvance.Piano();
            }
            if (owlBas)
            {
                owlAdvance.Bas();
            }
            if(owlBanjo)
            {
                owlAdvance.Banjo();
            }
            if (owlTrumpet)
            {
                owlAdvance.Trumpet();
            }
            if (owlOrgel)
            {
                owlAdvance.Orgel();
            }
        }
    }
    public void FollowPlayer()
    {
        follow = true;
    }

}
