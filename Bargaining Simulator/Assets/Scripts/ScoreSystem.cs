using System;
using System.Collections;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int Score
    {
        get
        {
            return NumItems + Discount;
        }
    }

    public int Discount
    {
        get
        {
            return NumItems - TimeElapsed; // TimeElapsed is seconds
        }
    }

    public int HighScore => PlayerPrefs.GetInt("highScore", 0);

    public int TimeElapsed { get; set; }
    public int Bonuses { get; private set; }
    public int BonusesCount { get; private set; }
    
    public int OriginalCost { get; set; } // Dirty code that probably isn't done properly but its 2am
    public int NewCost
    {
        get { return OriginalCost - Discount; }
    }
    public int NumItems { get; set; }

    public void AddBonus(int bonus)
    {
        Bonuses += bonus;
        BonusesCount++;
    }

    public void SaveHighScore()
    {
        if (Score > HighScore)
        {
            PlayerPrefs.SetInt("highScore", Score);
            PlayerPrefs.Save();
        }
    }

    private IEnumerator UpdateTime()
    {
        for (;;)
        {
            TimeElapsed++;
            yield return new WaitForSeconds(1f);
        }
    }
    
    public void StartScoreTime()
    {
        StartCoroutine(nameof(UpdateTime));
    }

    public void StopScoreTime()
    {
        StopAllCoroutines();
    }

    private static ScoreSystem instance;

    public static ScoreSystem GetInstance()
    {
        return instance;
    }

    public static void ResetScore()
    {
        Destroy(instance.gameObject);
        instance = null;
    }
    
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
}
