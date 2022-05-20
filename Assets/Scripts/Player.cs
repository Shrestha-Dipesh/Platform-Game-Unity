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

    private AudioSource audioSource;

    private void Awake()
    {
        //Get the required components of the player
        mRigidBody = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void Update()
    {
        MovePlayer();
        JumpPlayer();
        AnimatePlayer();

        GameObject mushroom = GameObject.Find("Mushroom C(Clone)");
        if (mushroom != null)
        {
            if (isFacingRight)
            {
                mushroom.transform.position = new Vector3(transform.position.x - 1.2f, transform.position.y + 2f, 0f);
                mushroom.transform.localScale = new Vector3(0.12f, 0.12f, 0.12f);
            }
            else
            {
                mushroom.transform.position = new Vector3(transform.position.x + 1.2f, transform.position.y + 2f, 0f);
                mushroom.transform.localScale = new Vector3(-0.12f, 0.12f, 0.12f);
            }
        }
    }

    private void MovePlayer()
    {
        //Move the player with arrow or A/D keys
        directionX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3 (directionX, 0f, 0f) * moveForce * Time.deltaTime;
        
        //Face the direction of movement
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
        //Jump the player with arrow or W keys
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && canJump)
        {
            canJump = false;
            mRigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            audioSource.PlayOneShot(Resources.Load<AudioClip>("Jump"));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Detect the object with which the player collided
        if (collision.gameObject.CompareTag("Platform"))
        {
            canJump = true;
            mAnimator.SetBool(JUMP_ANIMATION, false);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Kill the player
            mAnimator.SetBool("isDead", true);
            Destroy(mRigidBody);
            Destroy(GetComponent("Player"));
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.GameOver();

            if (gameManager.SelectedCharacter == "Player 1")
            {
                audioSource.PlayOneShot(Resources.Load<AudioClip>("Male Death"));
            }
            else
            {
                audioSource.PlayOneShot(Resources.Load<AudioClip>("Female Death"));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Detect which collectible the player collided with
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            GameObject coinEffect = Instantiate(Resources.Load("Coin Effect") as GameObject);
            coinEffect.transform.position = collision.transform.position;
            audioSource.PlayOneShot(Resources.Load<AudioClip>("Coin"));

            //Increase coin
            FindObjectOfType<GameManager>().IncreaseCoin(1);
        }

        if (collision.gameObject.CompareTag("Mushroom"))
        {
            Destroy(collision.gameObject);
            GameObject mushroomEffect = Instantiate(Resources.Load("Mushroom Effect") as GameObject);
            mushroomEffect.transform.position = collision.transform.position;
            audioSource.PlayOneShot(Resources.Load<AudioClip>("Mushroom"));

            //Increase life of player
            FindObjectOfType<GameManager>().ChangeLife(1);
        }

        if (collision.gameObject.CompareTag("Emerald"))
        {
            //Complete the level
            Destroy(collision.gameObject);
            FindObjectOfType<GameManager>().LevelComplete();
        }

        if (collision.gameObject.CompareTag("Collectible"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void AnimatePlayer()
    {
        //Animate the player based on the movement, i.e., idle, running or jumping
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
        //Flip the player sprite
        Vector2 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }
}
