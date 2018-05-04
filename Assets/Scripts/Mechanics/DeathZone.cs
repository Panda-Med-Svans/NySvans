﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour {

    [SerializeField]
    private CharacterMovement charMovement;
    public float animDuration;

    // Use this for initialization
    void Start() {
        charMovement = GameObject.Find("Player").GetComponent<CharacterMovement>();
        Debug.Log(charMovement);
    }

    // Update is called once per frame
    void Update() {

    }




    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            charMovement.anim.SetTrigger("bad");
            charMovement.enabled = !charMovement.enabled;
            //stäng av charMovement på player
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
