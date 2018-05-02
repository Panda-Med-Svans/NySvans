using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

    private GameObject startHighscore;
    private GameObject pauseScreen;
    private GameObject pauseHigh;

    private GameObject startLeafTarget;
    private Text startLeafText;
    private GameObject pauseLeafTarget;
    private Text pauseLeafText;

    private GameObject startOwlTarget;
    private Text startOwlText;
    private GameObject pauseOwlTarget;
    private Text pauseOwlText;

    
    public string startLeaf;
    public string pauseleaf;
    public string startOwl;
    public string pauseOwl;
    [Space]
    public int leafCount;
    public int owlCount;

    void Start()
    {
        #region Finding Score Targets

        //Hittar parents till menyerna för att senare SetActive(false)
        startHighscore = GameObject.Find("StartHighscore");
        pauseScreen = GameObject.Find("Pause");
        pauseHigh = GameObject.Find("PauseHighscore");

        //Hittar Löv Highscore texten för start Skärms Highscore menyn
        startLeafTarget = GameObject.Find(startLeaf);
        startLeafText = startLeafTarget.GetComponentInChildren<Text>();

        //Hittar Löv Highscore texten för start Paus Highscore menyn
        pauseLeafTarget = GameObject.Find(pauseleaf);
        pauseLeafText = pauseLeafTarget.GetComponentInChildren<Text>();

        //Hittar Ugglor Highscore texten för start Paus Highscore menyn
        startOwlTarget = GameObject.Find(startOwl);
        startOwlText = startOwlTarget.GetComponentInChildren<Text>();

        //Hittar Ugglor Highscore texten för start Paus Highscore menyn
        pauseOwlTarget = GameObject.Find(pauseOwl);
        pauseOwlText = pauseOwlTarget.GetComponentInChildren<Text>();

        //Avaktiverar menyerna tills de ska användas igen
        startHighscore.SetActive(false);
        pauseScreen.SetActive(false);
        pauseHigh.SetActive(false);
        #endregion

        startLeafText.text = pauseLeafText.text = PlayerPrefs.GetInt("LeafScore", 0).ToString("Leafs: " + leafCount + " / 27 Leafs");
        startOwlText.text = pauseOwlText.text = PlayerPrefs.GetInt("OwlScore", 0).ToString("Owls: " + owlCount + " / 6 Owls");


        //startHighscore.SetActive(false);
        //pauseScreen.SetActive(false);
    }
    //lägg till en till pub text var för pausehighscore
    void Update ()
    {

    }
    public void Owl()
    {
        owlCount++;
        if (owlCount > PlayerPrefs.GetInt("OwlScore", 0))
        {
            PlayerPrefs.SetInt("OwlScore", owlCount);
            startOwlText.text = pauseOwlText.text = owlCount.ToString("Owls: " + owlCount + " / 6 Owls");
        }
        //Ändra highscore för ugglorna
    }
    public void NormalLeaf()
    {
        leafCount++;
        if(leafCount > PlayerPrefs.GetInt("LeafScore", 0))
        {
            PlayerPrefs.SetInt("LefScore", leafCount);
            startLeafText.text = pauseLeafText.text = leafCount.ToString("Leafs: " + leafCount + " / 27 Leafs");
        }
        //Ändra highscore för löven
    }
    public void SuperLeaf()
    {
        //Gör något extra
    }
    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("LeafScore");
        startLeafText.text = pauseLeafText.text = "Leafs: 0 / 27 Leafs";
        leafCount = 0;
        PlayerPrefs.DeleteKey("OwlScore");
        startOwlText.text = pauseOwlText.text = "Owls: 0 / 6 Owls";
        owlCount = 0;
    }
}
