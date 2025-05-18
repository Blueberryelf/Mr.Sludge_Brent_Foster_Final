using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using JetBrains.Annotations;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private SpawnManager spawnManagerScript;
    private MoveLeft moveLeftScript;
    private RepeatBackground repeatBackgroundScript;


    public TextMeshProUGUI titleText;
    public TextMeshProUGUI scoreText;
    public Button regularPlayButton;
    public Button hardPlayButton;
    public float score;

    private AudioSource playerAudio;
    public AudioClip backgroundMusic;

    private Buttons buttonScript;
    



    // Start is called before the first frame update
    void Start()
    {
        
        GameManagerStart();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            score = Time.timeSinceLevelLoad;
            scoreText.text = "Score: " + score;
        }
        

        if (playerControllerScript.gameOver == false)
        {
            
            //playerAudio.PlayOneShot(backgroundMusic, 1.0f);
        }
        else if (playerControllerScript.gameOver == true)
        {
            scoreText.gameObject.SetActive(true);
            titleText.gameObject.SetActive(true);
            regularPlayButton.gameObject.SetActive(true);
            hardPlayButton.gameObject.SetActive(true);
            playerAudio.Stop();
            
        }
            
    }

    public void GameManagerStart()
    {
        
        scoreText.gameObject.SetActive(true);
        titleText.gameObject.SetActive(false);
        regularPlayButton.gameObject.SetActive(false);
        hardPlayButton.gameObject.SetActive(false);
        score = 0;
        scoreText.text = "Score: " + score;

        playerAudio = GetComponent<AudioSource>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerControllerScript.GameStartController();
       
    }

    
}
