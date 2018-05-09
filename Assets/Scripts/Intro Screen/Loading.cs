using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {


    
    //1) börja ladda scen, vänta med att byta scen tills
    //2) spelat upp ljudet & visa text för storyn
    //3) fade till nya scenen

    [Tooltip("Namn på scen som ska laddas.")]
	public string levelName;
    [Tooltip("I sekunder")][Range(1.0f, 60.0f)]
    public float introDuration = 5f;
    private AsyncOperation async;
    private bool started;
    public AudioSource story;

    void Start()
    {
        StartCoroutine("Load");
    }

    void FixedUpdate()
    {
        if(started)
        {
            Debug.Log(introDuration -= Time.deltaTime);
        }
    }
    //public void StartLoading() {
    //     StartCoroutine("Load");
    //}

    IEnumerator Load() {
        Debug.LogWarning("ASYNC LOAD STARTED - " + "DO NOT EXIT PLAY MODE UNTIL SCENE LOADS... UNITY WILL CRASH");
        async = SceneManager.LoadSceneAsync(levelName);
        async.allowSceneActivation = false;
        started = true;
        StartCoroutine("Intro");
        yield return async;
    }
 
    public void ActivateScene() {
        async.allowSceneActivation = true;
    }

    IEnumerator Intro()
    {
        story.Play();
        yield return new WaitForSeconds(introDuration);
        async.allowSceneActivation = true;
    }
}
