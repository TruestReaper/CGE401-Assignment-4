/*
* John Chirayil
* Assignment 4 - Prototype 3
* Description: The script will allow the
* background to repeat as the player runs
* along the stage.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        // save the starting position as a Vector3
        startPosition = transform.position;

        // set repeatWidth to hald the width of the background using the Box Collider
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // if the background is farther to the left than the repeatWidth, reset it to its start position
        if (transform.position.x < startPosition.x - repeatWidth) 
        {
            transform.position = startPosition;
        }
    }
}
