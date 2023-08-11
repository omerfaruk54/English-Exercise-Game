using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnglishExercise.Scripts
{
    public class WordManager : MonoBehaviour
    {
        [SerializeField] private TextAsset wordData; // Kelime verilerinin bulunduğu metin dosyası

        private Dictionary<string, string> wordAnswerPairs = new Dictionary<string, string>();

        private void Awake()
        {
            InitializeWords();
        }

        public void InitializeWords()
        {
            string[] lines = wordData.text.Split('\n');
            foreach (string line in lines)
            {
                string[] pair = line.Split(',');
                if (pair.Length == 2)
                {
                    string word = pair[0].Trim();
                    string answer = pair[1].Trim();
                    wordAnswerPairs.Add(word.ToLower(), answer); // Kelimeleri küçük harflere dönüştürerek sözlüğe ekle
                }
            }
        }

        public string GetAnswer(string word)
        {
            word = word.ToLower(); // Gelen kelimeyi küçük harflere dönüştür
            if (wordAnswerPairs.ContainsKey(word))
            {
                return wordAnswerPairs[word];
            }
            else
            {
                Debug.LogError("Word not found: " + word);
                return string.Empty;
            }
        }

        public string GetRandomWord()
        {
            List<string> wordList = new List<string>(wordAnswerPairs.Keys);
            int randomIndex = Random.Range(0, wordList.Count);
            return wordList[randomIndex]; // Rastgele kelimeyi döndür (küçük harflerle)
        }
    }
}
