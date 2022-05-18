using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private float minDistance;
    private float maxDistance;

    private void Start()
    {
        minDistance = transform.position.x;
        maxDistance = transform.position.x + 3;
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        //Back and forth motion for enemy
        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, maxDistance - minDistance) + minDistance, transform.position.y, transform.position.z);
        
        //Flip the enemy when facing right
        if (transform.position.x == minDistance)
        {
            FlipEnemy();
        }
        else if (transform.position.x == maxDistance)
        {
            FlipEnemy();
        }    
    }

    private void FlipEnemy()
    {
        //Flip the enemy sprite
        Vector2 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
}
