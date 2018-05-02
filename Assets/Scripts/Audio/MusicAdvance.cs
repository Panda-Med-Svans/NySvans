using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAdvance : MonoBehaviour {

    private AudioSource bas;
    private AudioSource trummor;
    private AudioSource gitarr;
    private AudioSource banjo;

    void Start() {
        bas = GameObject.Find("Bas").GetComponent<AudioSource>();
        trummor = GameObject.Find("Trummor").GetComponent<AudioSource>();
        gitarr = GameObject.Find("Gitarr").GetComponent<AudioSource>();
        banjo = GameObject.Find("Banjo").GetComponent<AudioSource>();
    }

    //void Update() //för att testa att det går att "unmute" musiken
    //{
    //    if(Input.GetKey(KeyCode.A) && trummor.mute == true)
    //    {
    //        trummor.mute = !trummor.mute;
    //    }
    //}


    //public void LowerAmbience()
    //{
    //    if (somethingreached == false)
    //    {
    //        ambience.volume = Mathf.word för att sakta sänkas till något värde
    //        somethingreached = true;
    //    }
    //}


    #region Instrument delar

    public void Bas()
    {
        if (bas.mute == true)
        {
            bas.mute = !bas.mute;
        }
        else
        {
            Debug.Log("Plockade upp fler av Bas Ugglor än planerat");
        }
    }

    public void Trummor()
    {
        if (trummor.mute == true)
        {
            trummor.mute = !trummor.mute;
        }
        else
        {
            Debug.Log("Plockade upp fler av Trumm Ugglor än planerat");
        }
    }

    public void Gitarr()
    {
        if (gitarr.mute == true)
        {
            gitarr.mute = !gitarr.mute;
        }
        else
        {
            Debug.Log("Plockade upp fler av Gitarr Ugglor än planerat");
        }
    }

    public void Banjo()
    {
        if (banjo.mute == true)
        {
            banjo.mute = !banjo.mute;
        }
        else
        {
            Debug.Log("Plockade upp fler av Banjo Ugglor än planerat");
        }
    }

        #endregion

}
