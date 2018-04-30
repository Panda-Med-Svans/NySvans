using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    

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
