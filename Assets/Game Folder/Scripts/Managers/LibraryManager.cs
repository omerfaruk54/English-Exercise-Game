using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibraryManager : MonoBehaviour
{
    public TextAsset textFile; // Okunacak metin dosyası
    public Text textDisplay; // Metinleri göstereceğiniz UI Text bileşeni

    private void Start()
    {
        if (textFile != null && textDisplay != null)
        {
            string[] lines = textFile.text.Split('\n'); // Metin dosyasını satır satır ayır

            string fullText = string.Join("\n", lines); // Metinleri birleştirerek tek bir metin oluştur

            textDisplay.text = fullText; // UI Text bileşenine metni atayın
        }
    }
}
