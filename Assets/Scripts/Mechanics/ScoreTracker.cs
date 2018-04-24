using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour {

    public static int scorePoints;
    public int currentPoints;
    public int scoreMultiplier;
	
	void Update ()
    {
        currentPoints = scorePoints;
    }
    public void ScoreChange()
    {
        scorePoints += 1 * scoreMultiplier;
    }
    public void Owl()
    {
        Debug.Log("Do something here");
        //like unmute music track
        //add score for collecting an owl
    }
}
