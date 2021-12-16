using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ds : MonoBehaviour
{

   [SerializeField] bool isVs;
    void Start()
    {
        if (isVs)
        {
            if (battleSsystem.roundCount < 3)
                DontDestroyOnLoad(gameObject);
        }

        else
        {
            if (battleSystemAi.roundCount < 3)
                DontDestroyOnLoad(gameObject);
        }

    }

    private void Update()
    {
        if (isVs)
        {
            if (battleSsystem.roundCount == 3)
                Destroy(gameObject);
        }


        else
        {
            if (battleSystemAi.roundCount == 3)
                Destroy(gameObject);
        }
    }
}
