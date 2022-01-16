using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForward : MonoBehaviour
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
            if (value < 20)
            {
                movingspeed = value;
            }
        }
    }
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerControllerscript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    

    // Update is called once per frame
    void Update()
    {
        MovingSpeed += 0.02f * Time.deltaTime;
        if (playerControllerscript.gameover == false && gameManager.hasGameStarted)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * MovingSpeed);
        }
    }
}
