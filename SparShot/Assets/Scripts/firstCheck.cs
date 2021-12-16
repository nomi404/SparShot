using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstCheck : MonoBehaviour
{
     public int IsFirst;

   
    public bool check ()
    {
        
        IsFirst = PlayerPrefs.GetInt("IsFirst") ;
        if (IsFirst == 0) 
        {
            Debug.Log("CHecked");
            return false;
            //PlayerPrefs.SetInt("IsFirst", 1);
        } else {
            return true;
        }
    }

    public void tutorialDone()
    {
        PlayerPrefs.SetInt("IsFirst", 1);
    }
}
