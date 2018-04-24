using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlPickUp : MonoBehaviour
{

    private ScoreTracker callOwl;
    private OwlCollection callCollectSound;

    void Start()
    {
        callOwl = FindObjectOfType<ScoreTracker>();
        callCollectSound = FindObjectOfType<OwlCollection>();
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            callOwl.Owl();
            callCollectSound.OwlCollect();
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }


}
