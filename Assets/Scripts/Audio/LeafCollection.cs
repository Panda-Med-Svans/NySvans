using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafCollection : MonoBehaviour {

    public AudioSource leafCollect;
    
    

    public float currentPitch = 1;
    public float minPitch = 1f;
    public float maxPitch = 2f;
    public float smoothPitch = 5f;
    [Tooltip("How much the pitch is increasing with each pick up. Normal Pitch = 1, Max Pitch = 2")]
    public float pitchMultiplier = 0.15f;

    // Use this for initialization
    void Start()
    {
       
    }

    void Update()
    {
        leafCollect.pitch = currentPitch;
        //Debug.Log(leafCollect.pitch);
        if (currentPitch > 1)
        {
            //currentPitch -= smoothPitch * Time.deltaTime; //Works but results in slightly lower pitch when it goes down to 1(0.99whatever)
            currentPitch = Mathf.Lerp(currentPitch, minPitch, Time.deltaTime);
        }
        //currentPitch = Mathf.Lerp(currentPitch, minPitch, Time.deltaTime);    
    }
    
    //varje ny jingle lägger till en uppspelning av ljudfilen till en array

    public void PlayJingle()
    {
        currentPitch += pitchMultiplier;
        leafCollect.Play();
    }
}
