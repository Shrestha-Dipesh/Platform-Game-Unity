using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 temporaryPosition;
    private float minimumX, maximumX;

    private void Start()
    {
        //Get the player position
        player = GameObject.FindWithTag("Player").transform;

        //Set the camera limit
        minimumX = 0;
        maximumX = GameObject.Find("Finish Point").transform.position.x - 9f;
    }

    private void LateUpdate()
    {
        if (!player)
        {
            return;
        }

        //Set the camera position to player position
        temporaryPosition = transform.position;
        temporaryPosition.x = player.position.x + 5;
        temporaryPosition.y = player.position.y + 2.5f;

        //Stop the camera when the position reaches minimum or maximum position
        if (temporaryPosition.x < minimumX)
        {
            temporaryPosition.x = minimumX;
        }

        if (temporaryPosition.x > maximumX)
        {
            temporaryPosition.x = maximumX;
        }

        transform.position = temporaryPosition;
    }
}
