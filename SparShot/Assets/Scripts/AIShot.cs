using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShot : MonoBehaviour
{
    controllerballAi cs;
    public GameObject helper;
    public aiHelper helperScript;
    public float Power = 8f;
    public float maxDrag = 5;
    Rigidbody2D rb;
    public battleSystemAi bs;

    private void Awake()
    {
        cs = GetComponent<controllerballAi>();
        helper = GameObject.FindGameObjectWithTag("helper");
        helperScript = helper.GetComponent<aiHelper>();
        rb = GetComponent<Rigidbody2D>();
        bs = GameObject.FindGameObjectWithTag("battleSystemAi").GetComponent<battleSystemAi>();
    }
    private void OnEnable()
    {
        StartCoroutine(aiShot());

      
    }

    IEnumerator aiShot()
    {
        gameObject.GetComponent<TurnHandler>().enabled = true;
        if (helperScript.direction.y < 0)
        {
            helperScript.direction.y *= -1;
        }
        Vector2 direction2 = helperScript.direction * -1;
        
        Vector2 force = direction2;
        yield return new WaitForSeconds(3f);

        Vector2 clampedForce = Vector2.ClampMagnitude(force, maxDrag) * Power;

        rb.AddForce(clampedForce, ForceMode2D.Impulse);
        bs.p1TurnCount--;

        Destroy(bs.p1turnsRed[bs.p1TurnCount].gameObject);
        cs.turnChanged = true;
        bs.redTurnDestroy();
        GetComponent<AIShot>().enabled = false;
    }


}
