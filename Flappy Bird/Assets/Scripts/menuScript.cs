using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    /*  ADS  */
    private string adId = "3586307";
    private string videoad = "video";

    [System.Obsolete]
    void Start()
    {
        Monetization.Initialize(adId, true);
    }

    [System.Obsolete]
    public void start()
    {
        if (Monetization.IsReady(videoad))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(videoad) as ShowAdPlacementContent;
            if (ad != null)
            {
                ad.Show();
            }
        }

        SceneManager.LoadScene("PlayScene");
    }

    public void exit()
    {
        Application.Quit();
    }
}
