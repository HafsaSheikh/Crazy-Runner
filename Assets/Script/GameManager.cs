using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float timer = 0;
    float counter = 3;
    [SerializeField] GameObject timerText;
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] Text highScoreText;
    [SerializeField] Text scoreText;
    [SerializeField] Text scoreText2;
    [SerializeField] Text newHighscoreText;
    [SerializeField] Text coinGmaeoverTxt;
    //[SerializeField] Text coinTxt;
    [SerializeField] GameObject coinGamePanel;

    [SerializeField] GameObject countdownText;
    [SerializeField] GameObject countdownPanel;
    [SerializeField] AudioClip countdown3;
    [SerializeField] AudioClip countdown2;
    [SerializeField] AudioClip countdown1;
    [SerializeField] AudioClip goAudio;
    [SerializeField] AudioSource countdownAudio;


    public static int highScore;
    public int score;
    public  bool hasGameStarted;
    PlayerController playerController;
    private void Start()
    {
        LoadHighscore();
        Debug.Log("HighScore at game start" + highScore);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        countdownPanel.SetActive(true);
        timerText.SetActive(false);
        gameoverPanel.SetActive(false);
        coinGamePanel.SetActive(false);
        
    }

    void Update()
    {
        CountdownTextUpdater();
        CountDown();
        if (hasGameStarted)
        {
            coinGamePanel.SetActive(true);
            timerText.SetActive(true);
            ScoreTimer();
            //TimerTextUpdate();
            countdownPanel.SetActive(false);
            if (playerController.gameover)
            {
                Score();
                Gameover();
                
            }
        }
    }
    private void LateUpdate()
    {
        TimerTextUpdate();
    }
    void TimerTextUpdate()
    {
        timerText.gameObject.GetComponent<Text>().text = "000"+timer.ToString("0");
    }
    void ScoreTimer()
    {
        if(!playerController.gameover)
            timer++;
    }

    void CountDown()
    {
        if (counter > -1)
        {
            //int i = ((int)counter);
            counter -= Time.deltaTime;
            
             //if (i==0)
             //   countdownAudio.PlayOneShot(goAudio, 1.25f);
        }
        else
            hasGameStarted = true;
    }
        
        
    
    void CountdownTextUpdater()
    {
        if(counter>0)
            countdownText.gameObject.GetComponent<Text>().text = counter.ToString("0");
        else if(counter>=-1)
            countdownText.gameObject.GetComponent<Text>().text = "GO!";
        
    }

    public void Score()
    {
        score = (int)timer;
        if(highScore<score)
        {
            highScore = score;
            newHighscoreText.gameObject.SetActive(true);
            SaveHighscore();
        }
        //else
        //    
    }

    public void SaveHighscore()
    {
        PlayerPrefs.SetInt("highscore", highScore);
    }
    public void LoadHighscore()
    {

       highScore = PlayerPrefs.GetInt("highscore");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Gameover()
    {
        if (score > highScore)
            newHighscoreText.gameObject.SetActive(false);
        highScoreText.text = highScore.ToString();
        scoreText.text = score.ToString();
        scoreText2.text = score.ToString();
        coinGmaeoverTxt.text = PlayerController.gameCoin.ToString();
        gameoverPanel.SetActive(true);
        timerText.SetActive(false);
        
        coinGamePanel.SetActive(false);

    }

   
}
