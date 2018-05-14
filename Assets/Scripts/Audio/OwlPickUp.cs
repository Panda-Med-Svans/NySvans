using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlPickUp : MonoBehaviour
{

    private ScoreTracker callOwl;
    private OwlCollection callCollectSound;
    private MusicAdvance owlAdvance;
    private OwlFollow callFollowPlayer;
    public bool owlTrummor, owlBas, owlGitarr, owlBanjo;


    void Start()
    {
        callOwl = FindObjectOfType<ScoreTracker>();
        callCollectSound = FindObjectOfType<OwlCollection>();
        owlAdvance = FindObjectOfType<MusicAdvance>();
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            callOwl.Owl();                  //Ger score
            callCollectSound.OwlCollect();  //spelar upp jingle
            callFollowPlayer.FollowPlayer();
            //gameObject.SetActive(false);
            Debug.Log("Something activated");
            Destroy(gameObject);            //dödar objektet
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


}
