using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomHoleLogic : MonoBehaviour
{
    GameObject ballSpawn;
    GameObject holeSpawn;
    randomHole ball;
    randomHole hole;

    AudioSource aa;

    score sc;

    [SerializeField]AudioClip miss;

    [SerializeField] GameObject ps;

    bool Scored = false;
    private void Start()
    {
        ballSpawn = GameObject.FindGameObjectWithTag("ballSpawn");
        holeSpawn = GameObject.FindGameObjectWithTag("holeSpawn");
        ball = ballSpawn.GetComponent<randomHole>();
        hole = holeSpawn.GetComponent<randomHole>();
        sc = GameObject.FindGameObjectWithTag("score").GetComponent<score>();
        aa = GameObject.FindGameObjectWithTag("Green").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            aa.Play();
            Scored = true;
            Destroy(gameObject);
            Destroy(collision.gameObject);

            ball.randomSpawn();
            ball.spawnTime = ball.timeStartSpawn;

            hole.randomSpawn();
            hole.spawnTime = hole.timeStartSpawn;

            sc.scoreBall++;
            

        }
    }


    private void OnDestroy()
    {
        if (!Scored)
        {
            gameObject.GetComponent<DestroyerDelay>().ps();
            aa.PlayOneShot(miss);
        }

        else
        {
            Instantiate(ps, transform.position, transform.rotation);
            
        }
    }

}
