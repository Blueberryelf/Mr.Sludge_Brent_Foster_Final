using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepeatBackground : MonoBehaviour
{
    
    private PlayerController playerControllerScript;
    private float BackgroundBound = -22.14f;
    private Vector2 startPosOne = new Vector2(14,1);
    private Vector2 startPosTwo = new Vector2(14,1);

    public GameObject backgroundOne;
    public GameObject backgroundTwo;

    public Buttons buttonScript;
    // Start is called before the first frame update
    void Start()
    {
        RepeatBackgroundGameStart();
        
    }

    // Update is called once per frame
    void Update()
    {
       if (playerControllerScript.gameOver == false && transform.position.x < BackgroundBound && gameObject.CompareTag("Background"))
        {
            transform.position = startPosOne;
        }
        if (playerControllerScript.gameOver == false && transform.position.x < BackgroundBound && gameObject.CompareTag("Background2"))
        {
            transform.position = startPosTwo;
        }
    }

    public void RepeatBackgroundGameStart()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
}
