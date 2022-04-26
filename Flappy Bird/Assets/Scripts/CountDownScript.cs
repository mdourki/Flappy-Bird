using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownScript : MonoBehaviour
{
    Text countdownTxt;

    private void OnEnable()
    {
        countdownTxt = GetComponent<Text>();
        countdownTxt.text = "3";
        StartCoroutine(Countdown());
        
    }

    IEnumerator Countdown()
    {
        int i;
        for(i=3; i > 0 ; i--)
        {
            countdownTxt.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        if(i == 0)
        { SceneManager.LoadScene("game"); }
    }
}
