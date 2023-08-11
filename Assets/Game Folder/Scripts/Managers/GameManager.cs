using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace EnglishExercise.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI wordText, trueText, wrongText;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private WordManager wordManager;
        [SerializeField] private SoundManager soundManager;
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] GameObject trueImage, wrongImage, trueAnswer;

        public int trueCount = 0, wrongCount = 0;


        private void Start()
        {
            RandomWord();
            StartText();
            DisableObject();
        }

        private void Update()
        {

        }

        private void RandomWord()
        {
            string randomWord = wordManager.GetRandomWord();
            wordText.text = randomWord;
        }

        private void StartText()
        {
            trueText.text = "True: " + trueCount.ToString();
            wrongText.text = "Wrong: " + wrongCount.ToString();

        }

        IEnumerator TrueRoutine()
        {
            trueImage.SetActive(true);
            soundManager.PlayTrueSound();
            yield return new WaitForSeconds(1);
            trueImage.SetActive(false);

        }

        IEnumerator WrongRoutine()
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
                trueAnswer.GetComponent<TextMeshProUGUI>().text = " " + answer; // Doğru cevabı göster
                StartCoroutine(WrongRoutine());
            }

            inputField.text = ""; // Input alanını temizle
            RandomWord(); // Yeni bir kelime seç

            scoreManager.AddPoint(trueCount);
        }

        private void DisableObject()
        {
            trueImage.SetActive(false);
            wrongImage.SetActive(false);
            trueAnswer.SetActive(false);
        }
    }
}
