using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreUIManager : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text highScore;
    public GameObject newHighScore;
    public TMP_Text timeElapsed;
    public TMP_Text numItems;
    public TMP_Text originalCost;
    public TMP_Text discountedCost;

    // Can't be bothered to add these at 3am, they require more logic
    //public Image itemsImage;
    //public Image discountImage;
    //public GradeImage[] itemImages;
    //public GradeImage[] discountImages;
    
    // Start is called before the first frame update
    void Start()
    {
        ScoreSystem scoreSystem = ScoreSystem.GetInstance();
        score.text += scoreSystem.Score.ToString();
        highScore.text += scoreSystem.HighScore.ToString();
        timeElapsed.text += scoreSystem.TimeElapsed + " seconds";
        numItems.text += scoreSystem.NumItems.ToString();
        originalCost.text += scoreSystem.OriginalCost;
        discountedCost.text += scoreSystem.NewCost;
        newHighScore.SetActive(scoreSystem.Score > scoreSystem.HighScore);
        scoreSystem.SaveHighScore();
        
        ScoreSystem.ResetScore();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    [System.Serializable]
    public struct GradeImage
    {
        public Sprite sprite;
        public int minScore;

        public static GradeImage GetImageFromScore(GradeImage[] images, int score)
        {
            GradeImage lastImage = images[images.Length - 1];
            foreach (var image in images)
            {
                if (image.minScore <= score && lastImage.minScore <= image.minScore)
                    lastImage = image;
            }

            return lastImage;
        }
        
        public static Sprite GetSpriteFromScore(GradeImage[] images, int score)
        {
            return GetImageFromScore(images, score).sprite;
        }
    }
}
