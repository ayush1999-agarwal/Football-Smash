using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadNextScene()
    {
        int CurrenrtSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrenrtSceneIndex + 1);
    }
    public void LoadStartScene()
    {
        FindObjectOfType<GameSession>().RestartScore();
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
