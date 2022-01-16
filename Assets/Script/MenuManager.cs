using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
        [SerializeField] GameObject menuSelectionScreen;
        [SerializeField] GameObject levelSelectionScreen;
        [SerializeField] Slider volumeSlider;
        [SerializeField] GameObject settingsScreen;
        [SerializeField] GameObject guideScreen;
        [SerializeField] Text coinText;
        public int size = 3;
        public bool[] levelUnlocked = new bool[3] { true, false ,false};
        public GameObject[] levelPanels;
    
      
        public static int highscore;
        int coins;


  


    private void Start()
    {
        StartGame();
        
       

    }
    
    // Update is called once per frame
 
    public void StartGame()
    {
        menuSelectionScreen.SetActive(true);
        levelSelectionScreen.SetActive(false);
        settingsScreen.SetActive(false);
        guideScreen.SetActive(false);

        if (!PlayerPrefs.HasKey("volumeValue"))
        {
            PlayerPrefs.SetFloat("volumeValue", volumeSlider.value);
            LoadData();
        }

        else
        {
            LoadData();
        }

        //if (!PlayerPrefs.HasKey("Coin"))
            CoinTextUpdate();
       // else
           // coinText.text = "0";

    }

    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        SaveData();
    }
    public void SaveData()
    {
        PlayerPrefs.SetFloat("volumeValue", volumeSlider.value);
    }
    public void LoadData()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volumeValue");
    }


    
   public void StartLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void CoinTextUpdate()
    {
        //Debug.Log("Treasure.totalCoins"+Treasure.totalCoins);
        coins = PlayerPrefs.GetInt("Coin");
        coinText.text = coins.ToString();

    }

//    public void Exit()
//    {

//#if UNITY_EDITOR
//        EditorApplication.ExitPlaymode();
//#else
//        Appliction.Quit();
//#endif

//    }
}
