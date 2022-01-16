using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    public LevelsBluprint[] levels;
    // Start is called before the first frame update
    void Start()
    {
      foreach(LevelsBluprint level in levels)
        {
            if (level.price == 0)
                level.isUnlocked = true;
            else
            {
                level.isUnlocked = PlayerPrefs.GetInt(level.name, 0) == 0 ? false : true;
            }

        }
    }
    private void Update()
    {
        UpdateLevelUI ();
    }


    public void BuyLevel(int index)
    {
        LevelsBluprint level = levels[index];
        PlayerPrefs.SetInt(level.name, 1);
        level.isUnlocked = true;
        PlayerPrefs.SetInt("Coin", (PlayerPrefs.GetInt("Coin", 0) - level.price));
    }

    public void UpdateLevelUI()
    {
        foreach(LevelsBluprint level in levels)
        {
            if(level.isUnlocked)
            {
                level.playButton.gameObject.SetActive(true);
                level.buyButton.gameObject.SetActive(false);
            }

            else
            {
                level.playButton.gameObject.SetActive(false);
                level.buyButton.gameObject.SetActive(true);
                level.buyButton.GetComponentInChildren<Text>().text = "$"+level.price;

                if (level.price <= PlayerPrefs.GetInt("Coin"))
                {
                    level.buyButton.interactable = true;
                }

                else
                    level.buyButton.interactable = false;

            }
        }
    }
    
}
