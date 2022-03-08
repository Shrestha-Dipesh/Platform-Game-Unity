using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 temporaryPosition;

    [SerializeField]
    private float minimumX, maximumX;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
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
