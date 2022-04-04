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
    private Animator mAnimator;

    private float directionX;
    private bool canJump = true;
    private bool isFacingRight = true;
    private string RUN_ANIMATION = "isRunning";
    private string JUMP_ANIMATION = "isJumping";

    private void Awake()
    {
        mRigidBody = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        MovePlayer();
        JumpPlayer();
        AnimatePlayer();
    }

    private void MovePlayer()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3 (directionX, 0f, 0f) * moveForce * Time.deltaTime;

        if (directionX > 0f && !isFacingRight)
        {
            FlipPlayer();
        }
        else if (directionX < 0f && isFacingRight)
        {
            FlipPlayer();
        }
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
            mAnimator.SetBool(JUMP_ANIMATION, false);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            mAnimator.SetBool("isDead", true);
            Destroy(mRigidBody);
            Destroy(GetComponent("Player"));
            FindObjectOfType<GameManager>().GameOver();
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
            FindObjectOfType<GameManager>().LevelComplete();
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            FindObjectOfType<GameManager>().IncreaseCoin(1);
        }

        if (collision.gameObject.CompareTag("Mushroom"))
        {
            Destroy(collision.gameObject);
            FindObjectOfType<GameManager>().ChangeLife(1);
        }

        if (collision.gameObject.CompareTag("Emerald"))
        {
            Destroy(collision.gameObject);
            FindObjectOfType<GameManager>().LevelComplete();
        }
    }

    private void AnimatePlayer()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            mAnimator.SetBool(JUMP_ANIMATION, true);
            mAnimator.SetBool(RUN_ANIMATION, false);
        }
        else
        {
            if (directionX == 0)
            {
                mAnimator.SetBool(RUN_ANIMATION, false);
            }
            else
            {
                mAnimator.SetBool(RUN_ANIMATION, true);
            }
        }
    }

    private void FlipPlayer()
    {
        Vector2 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }
}
