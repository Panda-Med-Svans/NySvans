using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAdvance : MonoBehaviour {

    private AudioSource trummor;
    private AudioSource trumpet;
    private AudioSource gitarr;
    private AudioSource orgel;
    private AudioSource piano;
    private AudioSource banjo;
    private AudioSource bas;
    

    void Start()
    {
        trummor = GameObject.Find("Trummor").GetComponent<AudioSource>();
        trumpet = GameObject.Find("Trumpet").GetComponent<AudioSource>();
        gitarr = GameObject.Find("Gitarr").GetComponent<AudioSource>();
        orgel = GameObject.Find("Orgel").GetComponent<AudioSource>();
        piano = GameObject.Find("Piano").GetComponent<AudioSource>();
        banjo = GameObject.Find("Banjo").GetComponent<AudioSource>();
        bas = GameObject.Find("Bas").GetComponent<AudioSource>();
    }

    //void Update() //för att testa att det går att "unmute" musiken
    //{
    //    if(Input.GetKey(KeyCode.A) && trummor.mute == true)
    //    {
    //        trummor.mute = !trummor.mute;
    //    }
    //}



    #region Pausa Musik

    public void MusicPause()
    {
        //Pausa alla musikspår
        trummor.Pause();
        trumpet.Pause();
        gitarr.Pause();
        orgel.Pause();
        piano.Pause();
        banjo.Pause();
        bas.Pause();

    }

    #endregion

    #region Unmute Instrument

    public void Trummor()
    {
        if (trummor.mute == true)
        {
            //Debug.Log("Trummor unmuted");
            trummor.mute = !trummor.mute;
        }
        else
        {
            Debug.Log("Plockade upp fler av Trummor Ugglor än planerat");
        }
    }

    public void Trumpet()
    {
        if (trumpet.mute == true)
        {
            //Debug.Log("Trumpet unmuted");
            trumpet.mute = !trumpet.mute;
        }
        else
        {
            Debug.Log("Plockade upp fler av Trumpet Ugglor än planerat");
        }
    }

    public void Gitarr()
    {
        if (gitarr.mute == true)
        {
            //Debug.Log("Gitarr unmuted");
            gitarr.mute = !gitarr.mute;
        }
        else
        {
            Debug.Log("Plockade upp fler av Gitarr Ugglor än planerat");
        }
    }

    public void Orgel()
    {
        if (orgel.mute == true)
        {
            //Debug.Log("Orgel unmuted");
            orgel.mute = !orgel.mute;
        }
        else
        {
            Debug.Log("Plockade upp fler av Orgel Ugglor än planerat");
        }
    }

    public void Piano()
    {
        if (piano.mute == true)
        {
            //Debug.Log("Piano unmuted");
            piano.mute = !piano.mute;
        }
        else
        {
            Debug.Log("Plockade upp fler av Piano Ugglor än planerat");
        }
    }

    public void Banjo()
    {
        if (banjo.mute == true)
        {
            //Debug.Log("Banjo unmuted");
            banjo.mute = !banjo.mute;
        }
        else
        {
            Debug.Log("Plockade upp fler av Banjo Ugglor än planerat");
        }
    }

    public void Bas()
    {
        if (bas.mute == true)
        {
            //Debug.Log("Bas unmuted");
            bas.mute = !bas.mute;
        }
        else
        {
            Debug.Log("Plockade upp fler av Bas Ugglor än planerat");
        }
    }

    #endregion

}
