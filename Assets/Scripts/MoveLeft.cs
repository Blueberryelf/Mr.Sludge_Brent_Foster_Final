using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30;
    private PlayerController  playerControllerScript;
    private float leftBound = -20;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Tree"))
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < leftBound && gameObject.CompareTag("Rock"))
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < leftBound && gameObject.CompareTag("Fairy"))
        {
            Destroy(gameObject);
        }

    }
}
