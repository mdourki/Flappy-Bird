using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.Monetization;

public class PlayerControl : MonoBehaviour
{
    public AudioClip jumpSound;
    public AudioClip scoreSound;
    public AudioClip deadSound;

    public GameObject tap;
    public GameObject die;
    public GameObject scorezone;

    public GameObject elementToSpawn;
    public GameObject blacksunflowerseeds;

    public float tapForce;
    public float tilt;

    public Vector3 StartPosition;

    Rigidbody2D playerRigidbody;

    Quaternion forwardRotation;
    Quaternion downRotation;

    public GameObject GameOverPage;

    //int i;
    int score;

    public int playerSpeed;

    public Text ScoreTxt;

    /*  ADS  */
    private string adId = "3586307";
    private string videoad = "video";

    [System.Obsolete]
    void Start()
    {
        Monetization.Initialize(adId, true);

        playerRigidbody = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0, 0, -90);
        forwardRotation = Quaternion.Euler(0, 0, 30);
        GameOverPage.SetActive(false);
        score = 0;

        Vector3 positionSpawn = new Vector3(5.33f, Random.Range(-1.5f, 1.5f) , -5.410544f);
        Instantiate(elementToSpawn, positionSpawn, Quaternion.identity);

        Vector3 positionSpawnBlackSunFlowerDeeds = new Vector3(7.83f, Random.Range(-1.5f, 1.5f), -5.410544f);
        Instantiate(blacksunflowerseeds, positionSpawnBlackSunFlowerDeeds, Quaternion.identity);
    }


    void Update()
    {
        ScoreTxt.text = score.ToString();

        transform.Translate(Vector2.right * playerSpeed * Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            tap.GetComponent<AudioSource>().PlayOneShot(jumpSound);
            transform.rotation = forwardRotation;
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.AddForce(Vector3.up * tapForce , ForceMode2D.Force);
            
        }

         transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tilt * Time.deltaTime);
    
    }

    /*private void OnEnable()
    {
        StartCoroutine(pause1second());        
    }*/

    /*IEnumerator pause1second()
    {
        int i;
        for (i = 0; i<16 ; i++)
        {
            if (i!=0 && i % 15 == 0)
            {
                Vector3 positionSpawnBlackSunFlowerDeeds = new Vector3(transform.position.x + 20f , Random.Range(-1.5f, 1.5f), -5.410544f);
                Instantiate(blacksunflowerseeds, positionSpawnBlackSunFlowerDeeds, Quaternion.identity);

            }

            yield return new WaitForSeconds(1f);  
        }
    }*/

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "DeadZone")
        {
            die.GetComponent<AudioSource>().PlayOneShot(deadSound);

            playerRigidbody.simulated = false;

            PlayerPrefs.SetInt("deadCounter", PlayerPrefs.GetInt("deadCounter") + 1);

            if(PlayerPrefs.GetInt("deadCounter") % 4 == 0)
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
            }

            GameOverPage.SetActive(true);

            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }

            GetComponent<PlayerControl>().enabled = false;
        }

        if (other.gameObject.tag == "Spawn Zone")
        {
            Vector3 positionSpawn = new Vector3(other.transform.position.x + 5f, Random.Range(-1.5f , 1.5f) , -5.410544f);
            Instantiate(elementToSpawn, positionSpawn, Quaternion.identity);
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "coin")
        {
                scorezone.GetComponent<AudioSource>().PlayOneShot(scoreSound);
                score += 10;
                Vector3 positionSpawnBlackSunFlowerDeeds = new Vector3(other.gameObject.transform.position.x + 120f, Random.Range(-1.5f, 1.5f), -5.410544f);
                Instantiate(blacksunflowerseeds, positionSpawnBlackSunFlowerDeeds, Quaternion.identity);

                Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "spawnSunFlowerSeeds")
        {
            Vector3 positionSpawnBlackSunFlowerDeeds = new Vector3(other.gameObject.transform.position.x + 50f, Random.Range(-1.5f, 1.5f), -5.410544f);
            Instantiate(blacksunflowerseeds, positionSpawnBlackSunFlowerDeeds, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ScoreZone")
        {
            //Incrementer le score
            score++;
            //play a sound
            scorezone.GetComponent<AudioSource>().PlayOneShot(scoreSound);
            Destroy(collision.gameObject);
        }
    }
   
}
