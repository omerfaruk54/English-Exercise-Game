using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace EnglishExercise.Scripts
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI trueText, highScoreText;
        private int score, highScore;

        private void Start()
        {
            highScore = PlayerPrefs.GetInt("HighScore", 0);
            highScoreText.text = "High Score: " + highScore.ToString();
        }

        public void AddPoint(int points)
        {
            score = points;
            trueText.text = "Score: " + score.ToString();

            if (score > highScore)
            {
                highScore = score;
                highScoreText.text = "High Score: " + highScore.ToString();
                PlayerPrefs.SetInt("HighScore", highScore);
            }
        }
    }
}
