using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CollisonHandler : MonoBehaviour
{

    [Tooltip ("In seconds")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX player")] [SerializeField] GameObject DeathFX;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        Instantiate(DeathFX, transform.position, transform.rotation);
        //Destroy(gameObject);
        Invoke("ReloadScene", levelLoadDelay);
    }

    private void ReloadScene()
    {
        
        SceneManager.LoadScene("Level1");
        //ScoreBoard.ResetScore();
    }
}
