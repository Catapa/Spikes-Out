using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Text DescriptionText;
    public Text NextLevelDescriptionText;
    public Text LevelCounterText;
    public Text CostText;

    int duration, durationNextLevel;
    int level;
    int cost;
  
    struct LevelsAttributes
    {
        public int cost;
        public int duration;
    };

    ///////////Levels for 2X Multiplier

    LevelsAttributes[] Levels_2XMultiplier = {
        new LevelsAttributes{ duration = 5, cost = 250 }, // Level 1
        new LevelsAttributes{ duration = 6, cost = 500 }, // Level 2
        new LevelsAttributes{ duration = 7, cost = 750 }, // Level 3
        new LevelsAttributes{ duration = 8, cost = 1000 }, // Level 4
        new LevelsAttributes{ duration = 9, cost = 1500 }, // Level 5
        new LevelsAttributes{ duration = 10, cost = 2000 }, // Level 6
        new LevelsAttributes{ duration = 12, cost = 3000 }, // Level 7
        new LevelsAttributes{ duration = 15, cost = 4000 }, // Level 8
        new LevelsAttributes{ duration = 17, cost = 5000 }, // Level 9
        new LevelsAttributes{ duration = 20, cost = -1 }, // Level 10
    };
    int TotalLevels_2XMultiplier = 10;

    ///////////////Levels for Magnet

    LevelsAttributes[] Levels_Magnet = {
        new LevelsAttributes{ duration = 5, cost = 300 }, // Level 1
        new LevelsAttributes{ duration = 6, cost = 600}, // Level 2
        new LevelsAttributes{ duration = 7, cost = 900 }, // Level 3
        new LevelsAttributes{ duration = 8, cost = 1200 }, // Level 4
        new LevelsAttributes{ duration = 9, cost = 1500 }, // Level 5
        new LevelsAttributes{ duration = 10, cost = 3000 }, // Level 6
        new LevelsAttributes{ duration = 12, cost = 5000 }, // Level 7
        new LevelsAttributes{ duration = 15, cost = 7000 }, // Level 8
        new LevelsAttributes{ duration = 17, cost = 10000 }, // Level 9
        new LevelsAttributes{ duration = 20, cost = -1 }, // Level 10
    };
    int TotalLevels_Magnet = 10;

    ////////////////Levels for Magnet

    LevelsAttributes[] Levels_Shield = {
        new LevelsAttributes{ duration = 5, cost = 500 }, // Level 1
        new LevelsAttributes{ duration = 6, cost = 750}, // Level 2
        new LevelsAttributes{ duration = 7, cost = 1000 }, // Level 3
        new LevelsAttributes{ duration = 8, cost = 1500 }, // Level 4
        new LevelsAttributes{ duration = 9, cost = 2000 }, // Level 5
        new LevelsAttributes{ duration = 10, cost = 3500 }, // Level 6
        new LevelsAttributes{ duration = 12, cost = 7000 }, // Level 7
        new LevelsAttributes{ duration = 15, cost = 10000 }, // Level 8
        new LevelsAttributes{ duration = 17, cost = 15000 }, // Level 9
        new LevelsAttributes{ duration = 20, cost = -1 }, // Level 10
    };
    int TotalLevels_Shield = 10;

    // Start is called before the first frame update
    void Start()
    {

        string DurationPlayerPrefs = "Duration " + gameObject.name;
        string LevelPlayerPrefs = "Level " + gameObject.name;
        string CostPlayerPrefs = "Cost " + gameObject.name;
        

        //Set level
        level = PlayerPrefs.GetInt(LevelPlayerPrefs);
        LevelCounterText.text = "Level: " + level.ToString() + "/10";

        //Set duration and descriptions
        switch (gameObject.name)
        {
            case "2X Multiplier":
                UpdateInfo("2X Multiplier");
                break;

            case "Magnet":
                UpdateInfo("Magnet");
                break;

            case "Shield":
                UpdateInfo("Shield");
                break;
        }

        //Set cost
        cost = PlayerPrefs.GetInt(CostPlayerPrefs);
        if (cost == -1)
            CostText.text = "MAX";
        else
            CostText.text = cost.ToString();
    }

    public void UpgradeMultiplier2X()
    {
        PayAmountOfCoins(PlayerPrefs.GetInt("Cost 2X Multiplier"));
        level = PlayerPrefs.GetInt("Level 2X Multiplier");
        
        if (level <= TotalLevels_2XMultiplier - 1)
        {
            
            //Set new durations
            duration = PlayerPrefs.GetInt("Duration 2X Multiplier");
            durationNextLevel = Levels_2XMultiplier[level].duration; 

            //Update PlayerPrefs
            PlayerPrefs.SetInt("Duration 2X Multiplier", durationNextLevel);
            PlayerPrefs.SetInt("Cost 2X Multiplier", Levels_2XMultiplier[level].cost);
            PlayerPrefs.SetInt("Level 2X Multiplier", level + 1);
        }
        UpdateInfo("2X Multiplier");
    }

    public void UpgradeMagnet()
    {
        PayAmountOfCoins(PlayerPrefs.GetInt("Cost Magnet"));
        level = PlayerPrefs.GetInt("Level Magnet");

        if (level <= TotalLevels_Magnet - 1)
        {
            //Set new durations
            duration = PlayerPrefs.GetInt("Duration Magnet");
            durationNextLevel = Levels_Magnet[level].duration;

            //Update PlayerPrefs
            PlayerPrefs.SetInt("Duration Magnet", durationNextLevel);
            PlayerPrefs.SetInt("Level Magnet", level + 1);
            PlayerPrefs.SetInt("Cost Magnet", Levels_Magnet[level].cost);
        }
        UpdateInfo("Magnet");

    }

    public void UpgradeShield()
    {
        PayAmountOfCoins(PlayerPrefs.GetInt("Cost Shield"));
        level = PlayerPrefs.GetInt("Level Shield");

        if (level <= TotalLevels_Shield - 1)
        {
            //Set new durations
            duration = PlayerPrefs.GetInt("Duration Shield");
            durationNextLevel = Levels_Shield[level].duration;

            //Update PlayerPrefs
            PlayerPrefs.SetInt("Duration Shield", durationNextLevel);
            PlayerPrefs.SetInt("Level Shield", level + 1);
            PlayerPrefs.SetInt("Cost Shield", Levels_Shield[level].cost);
        }
        UpdateInfo("Shield");
    }

    void UpdateInfo(string PowerUpName)
    {
        level = PlayerPrefs.GetInt("Level " + PowerUpName);
        duration = PlayerPrefs.GetInt("Duration " + PowerUpName);
        cost = PlayerPrefs.GetInt("Cost " + PowerUpName);

        LevelCounterText.text = "Level: " + level + "/" + TotalLevels_2XMultiplier;
        CostText.text = cost.ToString();

        switch (PowerUpName)
        {
            case "2X Multiplier":
                DescriptionText.text = "Multiplies score by 2 for " + duration + "s";

                if (level >= TotalLevels_2XMultiplier)
                {
                    LevelCounterText.text = "Level: " + TotalLevels_2XMultiplier + "/" + TotalLevels_2XMultiplier;
                    CostText.text = "MAX";
                    NextLevelDescriptionText.text = "Max Level Reached. No further upgrading available";
                }
                else
                {
                    NextLevelDescriptionText.text = "Next Level: Multiplies score by 2 for " + Levels_2XMultiplier[level].duration + "s";
                }
                break;

            case "Magnet":
                DescriptionText.text = "Collect all coins for " + duration.ToString() + "s";

                if (level >= TotalLevels_Magnet)
                {
                    LevelCounterText.text = "Level: " + TotalLevels_Magnet + "/" + TotalLevels_Magnet;
                    CostText.text = "MAX";
                    NextLevelDescriptionText.text = "Max Level Reached. No further upgrading available";
                }
                else
                {
                    NextLevelDescriptionText.text = "Next level: Collect all coins for " + Levels_Magnet[level].duration + "s";
                }
                break;

            case "Shield":
                DescriptionText.text = "Have a protective shield for " + duration.ToString() + "s";

                if (level >= TotalLevels_Magnet)
                {
                    LevelCounterText.text = "Level: " + TotalLevels_Magnet + "/" + TotalLevels_Magnet;
                    CostText.text = "MAX";
                    NextLevelDescriptionText.text = "Max Level Reached. No further upgrading available";
                }
                else
                {
                    NextLevelDescriptionText.text = "Next level: Have a protective shield for " + Levels_Magnet[level].duration + "s";
                }
                break;

        }
        /*
        DescriptionText.text = "";
        NextLevelDescriptionText.text = "";
        */
    }

    void PayAmountOfCoins(int amountCoins)
    {
        int initialAmountOfCoins = PlayerPrefs.GetInt("Coins");
        int finalAmountOfCoins = initialAmountOfCoins - amountCoins;
        PlayerPrefs.SetInt("Coins", finalAmountOfCoins);
    }
}
