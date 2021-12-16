using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteHandler : MonoBehaviour
{
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        posCheck();
    }

    void posCheck()
    {
        if (transform.position.y > 0)
        {
            gameObject.tag = "Player2";
            sr.color = Color.green;
            // sr.color = new Color(83/*Red*/, 190/*Green*/, 94/*Blue*/);
        }
        else if (transform.position.y < 0)
        {
            gameObject.tag = "Player";
            sr.color = Color.gray;
            //sr.color = new Color(91/*Red*/, 100/*Green*/, 226/*Blue*/);
        }


    }

}
