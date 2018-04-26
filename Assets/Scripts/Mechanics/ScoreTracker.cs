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
        //När man plockar upp ett löv;
        scorePoints += 1 * scoreMultiplier;
    }
    public void Owl()
    {
        //Om man redan har plockat en uggla av denna typen
        scorePoints += 1 * scoreMultiplier;
    }
    public void NormalLeaf()
    {
        //Gör något
    }
    public void SuperLeaf()
    {
        //Gör något extra
    }
}
