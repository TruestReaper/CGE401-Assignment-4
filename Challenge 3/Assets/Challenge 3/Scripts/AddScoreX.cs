/*
* John Chirayil
* Assignment 4 - Challenge 3
* Description: Score will increase when player
* collides with the Money object.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreX : MonoBehaviour
{
    private ScoreManagerX scoreManager;
    private bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManagerX>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            scoreManager.score++;
        }
    }
}
