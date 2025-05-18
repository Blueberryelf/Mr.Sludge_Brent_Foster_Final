using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDificutly);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDificutly()
    {
        Debug.Log(button.gameObject.name + "was clicked");
        gameManager.GameManagerStart();
    }

    
}

