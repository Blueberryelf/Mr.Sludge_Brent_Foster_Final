using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10;
    public float gravityModifier;
    private Rigidbody2D playerRb;
    public bool isOnGround = true;
    public bool gameOver;


    public bool hasPowerupJump = false;
    //public GameObject powerupIndicator;
    public GameObject powerupIndicatorJump;
    public int powerupJumpDuration = 3;

    public bool hasPowerupSheild = false;
    public GameObject powerupIndicatorSheild;
    public int powerupSheildDuration = 3;

    public bool isJumping = false;


    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioClip powerupJumpSound;
    public AudioClip powerupSheildSound;


    private AudioSource playerAudio;
    




    // Start is called before the first frame update
    void Start()
    {

        
        GameStartController();
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        powerupIndicatorSheild.transform.position = transform.position + new Vector3(0, 0, 0);
        powerupIndicatorJump.transform.position = transform.position + new Vector3(0.1f, 0.2f, 0);

        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround && !gameOver && !isJumping)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            isOnGround = false;
            isJumping = true;



        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) && hasPowerupJump && !isOnGround && !gameOver && isJumping)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
            isJumping = false;

        }
        //else isJumping = false;

        if (Input.GetKeyDown(KeyCode.DownArrow) && !gameOver)
        {
            playerRb.AddForce(Vector2.down * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            isJumping = false;

        }
        if (collision.gameObject.CompareTag("Fairy"))
        {
            if (hasPowerupSheild)
            {
                Destroy(collision.gameObject);
            }
            else gameOver = true;
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
        if (collision.gameObject.CompareTag("Tree"))
        {
            if (hasPowerupSheild)
            {
                Destroy(collision.gameObject);
            }
            else gameOver = true;
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
        if (collision.gameObject.CompareTag("Rock"))
        {
            if (hasPowerupSheild)
            {
                Destroy(collision.gameObject);
            }
            else gameOver = true;
            playerAudio.PlayOneShot(crashSound, 1.0f);

        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PowerupJump"))
        {
            Destroy(other.gameObject);

            playerAudio.PlayOneShot(powerupJumpSound, 1.0f);
            hasPowerupJump = true;
            powerupIndicatorJump.SetActive(true);
            StartCoroutine(PowerupJumpCooldownRoutine());
        }
        if (other.gameObject.CompareTag("PowerupSheild"))
        {
            Destroy(other.gameObject);

            playerAudio.PlayOneShot(powerupSheildSound, 1.0f);
            hasPowerupSheild = true;
            powerupIndicatorSheild.SetActive(true);
            StartCoroutine(PowerupSheildCooldownRoutine());
        }

    }

    IEnumerator PowerupJumpCooldownRoutine()
    {
        yield return new WaitForSeconds(powerupJumpDuration);
        hasPowerupJump = false;

        powerupIndicatorJump.SetActive(false);
    }

    IEnumerator PowerupSheildCooldownRoutine()
    {
        yield return new WaitForSeconds(powerupSheildDuration);
        hasPowerupSheild = false;
        powerupIndicatorSheild.SetActive(false);
    }

    public void GameStartController()
    {
        gameOver = false;
        playerAudio = GetComponent<AudioSource>();
        powerupIndicatorSheild.SetActive(false);
        powerupIndicatorJump.SetActive(false);
        playerRb = GetComponent<Rigidbody2D>();
        Physics2D.gravity *= gravityModifier;
    }

    

}

