using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlCollection : MonoBehaviour {

    public AudioSource owlCollect;



    // Use this for initialization
    void Start()
    {
        //
    }

    void Update()
    {
        //
    }

    //varje ny jingle lägger till en uppspelning av ljudfilen till en array

    public void OwlCollect()
    {
        owlCollect.Play();
    }
}
