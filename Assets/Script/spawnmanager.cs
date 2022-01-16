using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{// PlayerController script class ka ek variable liya
    private PlayerController playerControllerscript;
    public GameObject[] obstacle;
    private Vector3 position = new Vector3(22.56f, 0.023f, -2.29f);
    GameManager gameManager;
    void Start()
    {   
        playerControllerscript = GameObject.Find("Player").GetComponent<PlayerController>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        InvokeRepeating("spawning", 2f, Random.Range(1f, 2f));
        
    }
        void spawning()
        {// agr US script jo player controller ki haiy wo access ho rahi haiy to
        //uska gameover check hoga tabhi move kia jaiyga agay
        if (playerControllerscript.gameover == false && gameManager.hasGameStarted)
        {
            int randomObstacle = Random.Range(0, obstacle.Length);
            Instantiate(obstacle[randomObstacle], position, obstacle[randomObstacle].transform.rotation);
        }
        }
}
