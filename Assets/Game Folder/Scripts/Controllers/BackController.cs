using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackController : MonoBehaviour
{
    public void BackButton()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartGame(string restartSceneName)
    {
        SceneManager.LoadScene(restartSceneName);
    }

    public void OpenScene(string restartSceneName)
    {
        SceneManager.LoadScene(restartSceneName);
    }
}
