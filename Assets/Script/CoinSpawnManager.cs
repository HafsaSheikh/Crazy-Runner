using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnManager : MonoBehaviour
{
    private PlayerController playerControllerscript;
    public GameObject[] coin;
    private Vector3 position;//= new Vector3(22.56f, 0f, -2.29f);
    GameManager gameManager;
   
    void Start()
    {
        playerControllerscript = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


        InvokeRepeating("spawning", 2f, Random.Range(2f, 4f));

    }

    Vector3 RandomPosition()
    {
        return new Vector3(22.56f,Random.Range(0.8f, 2.5f), -1.59f);
    }
    void spawning()
    {// agr US script jo player controller ki haiy wo access ho rahi haiy to
        //uska gameover check hoga tabhi move kia jaiyga agay
        if (playerControllerscript.gameover == false && gameManager.hasGameStarted)
        {
            int randomCoin = Random.Range(0, coin.Length);
            Instantiate(coin[randomCoin], RandomPosition(), coin[randomCoin].transform.rotation);
        }
    }
}