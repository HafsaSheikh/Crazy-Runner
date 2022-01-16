using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLeftMove : MonoBehaviour
{
    PlayerController playerControllerscript;
    float movingspeed = 3;
    GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerControllerscript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (playerControllerscript.gameover == false && gameManager.hasGameStarted)
        {
            transform.Translate(Vector3.right * Time.deltaTime * movingspeed);
        }
    }
}
