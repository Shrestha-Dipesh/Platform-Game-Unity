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
        player = GameObject.FindWithTag("Player").transform;
        minimumX = 0;
        maximumX = GameObject.Find("Finish Point").transform.position.x - 9f;
    }

    private void LateUpdate()
    {
        if (!player)
        {
            return;
        }

        temporaryPosition = transform.position;
        temporaryPosition.x = player.position.x + 5;

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
