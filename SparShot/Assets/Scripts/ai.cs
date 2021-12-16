using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai : MonoBehaviour
{
    controllerballAi cs;
    public bool aiBool;
    public battleSystemAi bs;
    
   
    // Start is called before the first frame update
    void Start()
    {
        cs = GetComponent<controllerballAi>();
        bs = GameObject.FindGameObjectWithTag("battleSystemAi").GetComponent<battleSystemAi>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bs.state == gameState.Start) return;

        if (bs.state == gameState.p1Turn) {
            if (cs.belongsToPlayer1)
            {
               
             
                
               



            }
        }

    }
}
