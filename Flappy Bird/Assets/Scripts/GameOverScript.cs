using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void ReplayButton()
    {
        SceneManager.LoadScene("CountdownScene");
    }

    public void menuButton()
    {
        SceneManager.LoadScene("menu");
    }

    public void exitButton()
    {
        Application.Quit();
    }
}
