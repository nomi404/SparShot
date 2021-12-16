using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class formAi : MonoBehaviour
{
    [SerializeField] GameObject formation;

    [SerializeField] battleSystemAi bs;





    // Start is called before the first frame update
    public void selectFormation()
    {
        formation.SetActive(true);
        if (gameObject.tag == "imageP2")
            bs.blueSelected = true;


        if (gameObject.tag == "imageP1")
            bs.redSelected = true;


        this.transform.parent.gameObject.SetActive(false);




    }
}
