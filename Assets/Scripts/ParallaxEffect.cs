using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float length, startPosition;

    [SerializeField]
    private GameObject cam;

    [SerializeField]
    private float parallaxDepth;

    private void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        //Apply different speed with respect to the camera
        float distance = (cam.transform.position.x * parallaxDepth);
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

        //Repeat the background when the end is reached
        float temporaryPosition = (cam.transform.position.x * (1 - parallaxDepth));
        if (temporaryPosition > startPosition + length)
        {
            startPosition += length;
        }
        else if (temporaryPosition < startPosition - length)
        {
            startPosition -= length;
        }
    }
}
