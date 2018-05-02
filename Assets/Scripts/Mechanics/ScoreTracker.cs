using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

    public int leafCount;
    public Text leafText;
    [Space]
    public int owlCount;
    public Text owlText;

    void Start()
    {
        leafText.text = PlayerPrefs.GetInt("LeafScore", 0).ToString(leafCount + " Leafs out of 27 Leafs");
        owlText.text = PlayerPrefs.GetInt("OwlScore", 0).ToString(owlCount + " Owls out of Six Owls");
    }

    void Update ()
    {

    }
    public void Owl()
    {
        owlCount++;
        if (owlCount > PlayerPrefs.GetInt("OwlScore", 0))
        {
            PlayerPrefs.SetInt("OwlScore", owlCount);
            owlText.text = owlCount.ToString(owlCount + " Owls out of Six Owls");
        }
        //Ändra highscore för ugglorna
    }
    public void NormalLeaf()
    {
        leafCount++;
        if(leafCount > PlayerPrefs.GetInt("LeafScore", 0))
        {
            PlayerPrefs.SetInt("LefScore", leafCount);
            leafText.text = leafCount.ToString(leafCount  + " Leafs out of 27 Leafs");
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
        leafText.text = "0";
        leafCount = 0;
        PlayerPrefs.DeleteKey("OwlScore");
        owlText.text = "0";
        owlCount = 0;
    }
}
