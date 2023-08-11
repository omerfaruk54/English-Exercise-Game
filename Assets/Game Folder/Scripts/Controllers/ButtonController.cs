using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject mainMenuButtons;
    [SerializeField] GameObject challengeButtons;

    private void Start()
    {
        mainMenuButtons.SetActive(true);
        challengeButtons.SetActive(false);
    }

    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChallengeControl()
    {
        if (mainMenuButtons.activeSelf)
        {
            // Ana menü düğmeleri açıksa kapat
            mainMenuButtons.SetActive(false);
            DeactivateAllChildren(mainMenuButtons);
        }
        else
        {
            // Ana menü düğmeleri kapalıysa aç
            mainMenuButtons.SetActive(true);
            ActivateAllChildren(mainMenuButtons);
        }

        // Meydan okuma düğmelerini etkinleştir
        challengeButtons.SetActive(true);
        ActivateAllChildren(challengeButtons);
    }

    private void ActivateAllChildren(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            child.gameObject.SetActive(true);

            // Child'ın alt nesneleri varsa onları da etkinleştir
            ActivateAllChildren(child.gameObject);
        }
    }

    private void DeactivateAllChildren(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            child.gameObject.SetActive(false);

            // Child'ın alt nesneleri varsa onları da devre dışı bırak
            DeactivateAllChildren(child.gameObject);
        }
    }
}
