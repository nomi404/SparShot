using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trajectory : MonoBehaviour
{
     LineRenderer lr;

  
    

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    
    public void renderLine(Vector3 startPos,Vector3 endPos)
    {

        Vector3 pos = startPos - endPos;
        

        lr.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = startPos;
        points[1] = endPos;
        lr.SetPositions(points);
        

    }


    public void endLine()
    {
        lr.positionCount = 0;
    }
}
