using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public  float jumpforce;
    private Rigidbody jumper;

    public  float gravityModifier;
    private bool isonground = true;
    public bool gameover = false;
    private Animator playeranim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirt;
    public AudioSource bg;
    public AudioSource gover;

    public AudioClip jumpsound;
    public AudioClip coinSound;
    private AudioSource playeraudio;

    public static int gameCoin = 0;
    public static int totalCoins;
    [SerializeField] Text coinText;
    GameManager gameManager;
    void Start()
    {
        LoadCoin();
        bg.PlayDelayed(4f);
        jumper = GetComponent<Rigidbody>();
        playeranim = GetComponent<Animator>();
        playeraudio = GetComponent<AudioSource>();
        //jumper.AddForce(Vector3.up * jumpforce);
        // now ham gravity ko modify kriengay ye bs ek tarika haiy
        Physics.gravity *= gravityModifier;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.hasGameStarted)
        {
           // dirt.Play();
            //PlaySound();
            playeranim.SetFloat("Speed_f", 1);
            if (Input.GetMouseButtonDown(0) && isonground && !gameover) //timer>1.0f
            {
                jumper.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);

                isonground = false;
                playeranim.SetTrigger("Jump_trig");
                dirt.Stop();

                playeraudio.PlayOneShot(jumpsound, 1.0f);
            }
        }

        else
        {
            //bg.Pause();
         //   isonground = false;
            dirt.Stop();
            playeranim.SetFloat("Speed_f", 0);
            playeranim.SetInteger("Animation_int", 7);
        }
        
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (gameManager.hasGameStarted)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isonground = true;
                // playeranim.SetFloat("Speed_f", 1);
                dirt.Play();
            }
            else if (collision.gameObject.CompareTag("Obstacle")&& !gameover)
            {
                
                gameover = true;
                playeranim.SetBool("Death_b", true);
                playeranim.SetInteger("DeathType_int", 1);
                explosionParticle.Play();
                dirt.Stop();
                bg.Stop();
                gover.Play();
                bg.Stop();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            playeraudio.PlayOneShot(coinSound, 1.0f);
            gameCoin++;
            //gameManager.CollectedCoins();
            CoinTextUpdate();
            SaveCoin();
            Destroy(other.gameObject);
        }
    }

    public void CoinTextUpdate()
    {
        coinText.text = gameCoin.ToString();
    }
    public void SaveCoin()
    {
        if (PlayerPrefs.HasKey("Coin"))
        {
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + gameCoin);
        }
        else
        {
            PlayerPrefs.SetInt("Coin", gameCoin);
        }
    }


    public void LoadCoin()
    {
        totalCoins = PlayerPrefs.GetInt("Coin",0);
        Debug.Log("Load Data Called");
        Debug.Log("Treasure.totalCoins" + totalCoins);
    }

}