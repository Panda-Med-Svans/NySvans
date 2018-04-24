using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LevelSelect : MonoBehaviour
{
    //public AudioSource menuClick;
    public void Select(string levelName)
    {
        //menuClick.Play();
        SceneManager.LoadScene(levelName);
    }














}
//public void Options()
//{
//    //Load Options
//}
//public void Level1()
//{
//    //Load Level 1
//    SceneManager.LoadScene("PeopleScene");
//}
//public void Level2()
//{
//    //Load Level 1
//}