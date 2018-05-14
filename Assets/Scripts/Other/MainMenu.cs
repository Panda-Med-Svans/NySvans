using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public CharacterMovement startRun;

    void Start()
    {
        startRun = GameObject.Find("Panda").GetComponent<CharacterMovement>();
    }

    public void StartGame()
    {
        CharacterMovement.startRunning = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


}
