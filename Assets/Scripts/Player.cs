using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 7f;

    [SerializeField]
    private float jumpForce = 7f;

    private Rigidbody2D mRigidBody;
    private float directionX;
    private bool canJump = true;

    private void Awake()
    {
        mRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovePlayer();
        JumpPlayer();
    }

    private void MovePlayer()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3 (directionX, 0f, 0f) * moveForce * Time.deltaTime;
    }

    private void JumpPlayer()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && canJump)
        {
            canJump = false;
            mRigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            canJump = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().GameOver();
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().LevelComplete();
        }
    }
}
