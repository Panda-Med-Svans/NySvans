using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour {


    
    //1) börja ladda scen, vänta med att byta scen tills
    //2) spelat upp ljudet & visa text för storyn
    //3) fade till nya scenen

    [Tooltip("Namn på scen som ska laddas.")]
	public string levelName;
    [Tooltip("I sekunder")][Range(1.0f, 60.0f)]
    public float introDuration = 5f;
    private AsyncOperation async;
    public AudioSource story;
    //private bool started;
    public Text text;
    [Tooltip("Hur lång tid texten i sekunder det ska ta tills den är fullt synlig")]
    public float fadeInTime;


    void Start()
    {
        text = GameObject.Find("StoryNarration").GetComponent<Text>();
        StartCoroutine("Load");
        StartCoroutine(FadeIn());
        
    }

    void FixedUpdate()
    {
        //if(started)
        //{
        //    Debug.Log(introDuration -= Time.deltaTime);
        //}
    }


    IEnumerator Load() {
        async = SceneManager.LoadSceneAsync(levelName);
        async.allowSceneActivation = false;
        //started = true;
        StartCoroutine("Intro");
        yield return async;
    }
 
    public void ActivateScene() {
        async.allowSceneActivation = true;
    }

    IEnumerator Intro()
    {
        //fade in text
        story.Play();
        yield return new WaitForSeconds(introDuration);
        async.allowSceneActivation = true;
    }


    IEnumerator FadeIn()
    {
        Color originalColor = text.color;
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / fadeInTime));
            yield return null;
        }
    }
}
