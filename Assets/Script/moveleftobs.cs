using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class moveleftobs : MonoBehaviour
{   
    PlayerController playerControllerscript;
    float movingspeed = 5;
    GameManager gameManager;
    public float MovingSpeed
    {
        get
        {
            return movingspeed;
        }

        set
        {
            if(value<20)
            {
                movingspeed = value;
            }
        }
    }
    void Start()
    {
        playerControllerscript = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        MovingSpeed += 0.02f * Time.deltaTime;
        // MovingSpeed += 0.1f * Time.deltaTime; 
        if (playerControllerscript.gameover == false && gameManager.hasGameStarted)
        {
            transform.Translate(Vector3.right * Time.deltaTime * MovingSpeed);
        }
    }

 
}
