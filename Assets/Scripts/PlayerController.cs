using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10;
    public float gravityModifier;
    private Rigidbody2D playerRb;
    public bool isOnGround = true;
    public bool gameOver;


    public bool hasPowerupJump = false;
    public GameObject powerupIndicator;
    public int powerupJumpDuration = 3;

    public bool hasPowerupSheild = false;
    public GameObject powerupSheild;
    public int powerupSheildDuration = 3;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        Physics2D.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
            
            
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Fairy"))
        {
            gameOver = true;
        }
        if (collision.gameObject.CompareTag("Tree"))
        {
            gameOver = true;
        }

       // if (collision.gameObject.CompareTag("Tree") && hasPowerupSheild)
       // {
            //Destroy(gameObject.CompareTag("Tree"));
            
            
            
       // }

        

        if (collision.gameObject.CompareTag("Rock"))
        {
            gameOver = true;
        }
    
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PowerupJump"))
        {
            Destroy(other.gameObject);
            hasPowerupJump = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupJumpCooldownRoutine());
        }
        if (other.gameObject.CompareTag("PowerupSheild"))
        {
            Destroy(other.gameObject);
            hasPowerupSheild = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupSheildCooldownRoutine());
        }
        
    }

    IEnumerator PowerupJumpCooldownRoutine()
    {
        yield return new WaitForSeconds(powerupJumpDuration);
        hasPowerupJump = false;
        powerupIndicator.SetActive(false);
    }

    IEnumerator PowerupSheildCooldownRoutine()
    {
        yield return new WaitForSeconds(powerupSheildDuration);
        hasPowerupSheild = false;
        powerupIndicator.SetActive(false);
    }
}
