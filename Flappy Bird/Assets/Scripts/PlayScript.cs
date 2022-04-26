using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PlayScript : MonoBehaviour
{
    public Text highScoreTxt;
    
    private void Start()
    {
        highScoreTxt.text = "High Score : " + PlayerPrefs.GetInt("HighScore"); 
    }


    public void PlayButton()
    {
        SceneManager.LoadScene("CountdownScene");
    }
}
