using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveLeft : MonoBehaviour
{
    private float gameTimer;
    private float timePassed1 = 30;
    private float timePassed2 = 50f;
    private float timePassed3 = 75;
    private float timePassed4 = 100;
    private float timepPassed5 = 150;







    public float speed = 30;
    private PlayerController playerControllerScript;
    private float leftBound = -20;
    private Buttons buttonScript;
    
    // Start is called before the first frame update
    void Start()
    {
        MoveLeftGameStart();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);

            if (Time.timeSinceLevelLoad > timePassed1)
            {
                transform.Translate(Vector2.left * Time.deltaTime * 2 );

                if (Time.timeSinceLevelLoad > timePassed2)
                {
                    transform.Translate(Vector2.left * Time.deltaTime * 2);

                    if (Time.timeSinceLevelLoad > timePassed3)
                    {
                        transform.Translate(Vector2.left * Time.deltaTime * 2);

                        if (Time.timeSinceLevelLoad > timePassed4)
                        {
                            transform.Translate(Vector2.left * Time.deltaTime * 2);

                            if (Time.timeSinceLevelLoad > timepPassed5)
                            {
                                transform.Translate(Vector2.left * Time.deltaTime * 2);
                            }
                        }
                    }
                } 
               
            }
        }
         
        if (playerControllerScript.gameOver == false && transform.position.x < leftBound && gameObject.CompareTag("Tree"))
        {
            Destroy(gameObject);
        }
        else if (playerControllerScript.gameOver == false && transform.position.x < leftBound && gameObject.CompareTag("Rock"))
        {
            Destroy(gameObject);
        }
        else if (playerControllerScript.gameOver == false && transform.position.x < leftBound && gameObject.CompareTag("Fairy"))
        {
            Destroy(gameObject);
        }
        else if (playerControllerScript.gameOver == false && transform.position.x < leftBound && gameObject.CompareTag("PowerupSheild"))
        {
            Destroy(gameObject);
        }
        else if (playerControllerScript.gameOver == false && transform.position.x < leftBound && gameObject.CompareTag("PowerupJump"))
        { 
            Destroy(gameObject);
        }
        
        

    }

    public void MoveLeftGameStart()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
}
