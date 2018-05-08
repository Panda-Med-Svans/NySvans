using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafPickUp : MonoBehaviour {
    private ScoreTracker callScoreTracker;
    private LeafCollection callCollectSound;
    //public bool normalLeaf, superLeaf;

    void Start()
    {
        callScoreTracker = FindObjectOfType<ScoreTracker>();
        callCollectSound = FindObjectOfType<LeafCollection>();
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            callScoreTracker.NormalLeaf(); //delete om vi ska ha normal/super leafs
            callCollectSound.PlayJingle();
            //gameObject.SetActive(false);
            //if(normalLeaf)
            //{
            //callScoreTracker.NormalLeaf();
            //}
            //if(superLeaf
            //{
            //callScoreTracker.SuperLeaf();
            //}
            Destroy(gameObject);
            
        }
    }

    



}
