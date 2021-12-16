using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splash : MonoBehaviour
{

     battleSsystem bs;
    public ParticleSystem ps;

    int count = 0;
    int count2 = 0;
    private void OnEnable()
    {
        bs = GameObject.FindGameObjectWithTag("battleSystem").GetComponent<battleSsystem>();
        count = bs.p1TurnCount;
        count2 = bs.p2TurnCount;

    }
    private void Update()
    {
        if (count != bs.p1TurnCount && count2 != bs.p2TurnCount)
            StartCoroutine("Destroy");
    }


    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(ps,gameObject.transform.position,gameObject.transform.rotation);
        Destroy(gameObject);
    }




}
