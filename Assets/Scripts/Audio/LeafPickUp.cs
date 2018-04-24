using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafPickUp : MonoBehaviour {
    private ScoreTracker callScoreTracker;
    private LeafCollection callCollectSound;

    void Start()
    {
        callScoreTracker = FindObjectOfType<ScoreTracker>();
        callCollectSound = FindObjectOfType<LeafCollection>();
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            callScoreTracker.ScoreChange();
            callCollectSound.PlayJingle();
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    



}
