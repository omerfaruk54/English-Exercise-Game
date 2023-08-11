using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace EnglishExercise.Scripts
{
    public class ChallangeController : MonoBehaviour
    {
        [SerializeField] private TMP_Text wordText;
        [SerializeField] private TMP_Text countWordText;
        [SerializeField] private TMP_Text trueText;
        [SerializeField] private TMP_Text wrongText;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private WordManager wordManager;
        [SerializeField] private SoundManager soundManager;
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private GameObject trueImage;
        [SerializeField] private GameObject wrongImage;
        [SerializeField] private GameObject trueAnswer;
        [SerializeField] private GameObject gameOverImage;
        [SerializeField] private GameObject checkButton;

        [SerializeField] private int remainingWord;
        [SerializeField] private int trueCount = 0;
        [SerializeField] private int wrongCount = 0;



        private string[] wordList;
        private int currentIndex;

        private void Start()
        {
            wordList = new string[10];
            currentIndex = 0;
            AskTenWords();
            StartText();
            DisableObject();
        }

        private void AskTenWords()
        {
            for (int i = 0; i < wordList.Length; i++)
            {
                string randomWord = wordManager.GetRandomWord();
                wordList[i] = randomWord;
            }
            ShowQuestion();
        }


        private void ShowQuestion()
        {
            string currentWord = wordList[currentIndex];
            wordText.text = currentWord;
        }

        private void StartText()
        {
            trueText.text = "True: " + trueCount.ToString();
            wrongText.text = "Wrong: " + wrongCount.ToString();
            countWordText.text = "Remaining: " + remainingWord.ToString();
        }

        private IEnumerator TrueRoutine()
        {
            trueImage.SetActive(true);
            soundManager.PlayTrueSound();
            yield return new WaitForSeconds(1);
            trueImage.SetActive(false);
        }

        private IEnumerator WrongRoutine()
        {
            wrongImage.SetActive(true);
            trueAnswer.SetActive(true);
            soundManager.PlayWrongSound();
            yield return new WaitForSeconds(1);
            wrongImage.SetActive(false);
            trueAnswer.SetActive(false);
        }

        public void CheckWord()
        {
            string userInput = inputField.text;
            string answer = wordManager.GetAnswer(wordText.text);
            remainingWord--;
            countWordText.text = "Remaining: " + remainingWord.ToString();


            if (userInput.Equals(answer))
            {
                Debug.Log("Doğru kelime girişi!");
                trueCount++;
                trueText.text = "True: " + trueCount.ToString();
                StartCoroutine(TrueRoutine());
            }
            else
            {
                Debug.Log("Yanlış kelime girişi!");
                wrongCount++;
                wrongText.text = "Wrong: " + wrongCount.ToString();
                trueAnswer.GetComponent<TMP_Text>().text = " " + answer; // Doğru cevabı göster
                StartCoroutine(WrongRoutine());
            }

            inputField.text = ""; // Input alanını temizle

            currentIndex++;
            if (currentIndex < wordList.Length)
            {
                ShowQuestion();
            }
            else
            {
                Debug.Log("Tüm sorular tamamlandı!");
            }

            if (remainingWord == 0) 
            {
                checkButton.SetActive(false);
                gameOverImage.SetActive(true);
            }

            scoreManager.AddPoint(trueCount);
        }

        private void DisableObject()
        {
            trueImage.SetActive(false);
            wrongImage.SetActive(false);
            trueAnswer.SetActive(false);
            gameOverImage.SetActive(false);
        }
    }
}
