using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class randomHole : MonoBehaviour
{

    [SerializeField] float xRange1;
    [SerializeField] float xRange2;
    [SerializeField] float yRange1;
    [SerializeField] float yRange2;

    [SerializeField] GameObject objectToSpawn;

    public float timeStartSpawn;

    [SerializeField]float roundTime;
    [SerializeField] float time = 0;

    public float spawnTime=3f;
    [SerializeField] GameObject gameOver;

    bool firstTime;
   [SerializeField] TextMeshProUGUI temer;
   [SerializeField] showScore ss;
    float timeShow;
    public InterstitialAdExample ad;
    // Start is called before the first frame update
    void Start()
    {

        if(gameObject.tag=="ballSpawn")
        ad = GameObject.FindGameObjectWithTag("loadAd").GetComponent<InterstitialAdExample>();
        time = 0;
        timeShow = roundTime;
        
    }

    


   public void randomSpawn()
    {
        
        Vector2 newPos = Vector2.zero;
        newPos.x = Random.Range(xRange1, xRange2);
        newPos.y = Random.Range(yRange1, yRange2);

        Instantiate(objectToSpawn, newPos, Quaternion.identity);

    }
    // Update is called once per frame
    void Update()
    {
       
        
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            randomSpawn();
            spawnTime = timeStartSpawn;
        }
        time += Time.deltaTime;
        timeShow -= Time.deltaTime;


        if (time >= roundTime)
        {
            temer.text = "Time left: 0";
            gameObject.SetActive(false);

            if (gameObject.tag == "ballSpawn")
            {
                ad.ShowAd();
                gameOver.SetActive(true);
                ss.changeTrue = true;

            }



        }

        else
        {

            temer.text = "Time left: " + (int)timeShow;
        }
    }
}
