using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour {

    public MusicAdvance musicAdvance;
    public CharacterMovement charMovement;
    public float animDuration;

    // Use this for initialization
    void Start()
    {
        musicAdvance = GameObject.Find("SoundHandler").GetComponent<MusicAdvance>();
        charMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "Player")
        {
            charMovement.anim.SetTrigger("bad");
            charMovement.enabled = !charMovement.enabled;
            musicAdvance.MusicPause();
            //spela upp dödsanimationen
            StartCoroutine(ReloadAfterDeath());
        }

    }

    IEnumerator ReloadAfterDeath()
    {
        yield return new WaitForSeconds(animDuration);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // eller om man går till loading screen
    }
}
