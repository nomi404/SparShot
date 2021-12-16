using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragAi : MonoBehaviour
{
    // The plane the object is currently being dragged on
    Plane dragPlane;

    // The difference between where the mouse is on the drag plane and 
    // where the origin of the object is on the drag plane
    Vector3 offset;

    Camera myMainCamera;


    Vector3 originalPos;
    bool check = false;
    public float range = 1f;

    public bool poweredUp = false;

    Vector2 startPos;

    GameObject bs;

    void Start()
    {
        myMainCamera = Camera.main;
        originalPos = gameObject.transform.position;
        bs = GameObject.FindGameObjectWithTag("battleSystemAi");

    }

    void OnMouseDown()
    {
        startPos = transform.position;

        if (startPos.y > 0 && bs.GetComponent<battleSystemAi>().state == gameState.p1Turn || startPos.y < 0 && bs.GetComponent<battleSystemAi>().state == gameState.p2Turn)
        {
            dragPlane = new Plane(myMainCamera.transform.forward, transform.position);
            Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

            float planeDist;
            dragPlane.Raycast(camRay, out planeDist);
            offset = transform.position - camRay.GetPoint(planeDist);
        }
    }

    void OnMouseDrag()
    {
        if (startPos.y > 0 && bs.GetComponent<battleSystemAi>().state == gameState.p1Turn
            || startPos.y < 0 && bs.GetComponent<battleSystemAi>().state == gameState.p2Turn)
        {
            Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

            float planeDist;
            dragPlane.Raycast(camRay, out planeDist);
            transform.position = camRay.GetPoint(planeDist) + offset;
        }
    }


    private void OnMouseUp()
    {


        //check if there is something at that position
        if (gameObject.tag == "bluePowerUp" || gameObject.tag == "redPowerUp")
        {
            if (startPos.y > 0 && bs.GetComponent<battleSystemAi>().state == gameState.p1Turn)
            {
                Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, range);
                foreach (Collider2D hit in hitColliders)
                {
                    if (hit.gameObject.tag == "p1")
                    {
                        check = true;
                        if (check)
                        {
                            transform.parent = hit.gameObject.transform;
                            poweredUp = true;
                            hit.gameObject.GetComponent<controllerballAi>().Power = 30;

                        }
                        break;



                    }



                }

                if (!check)
                {
                    transform.position = originalPos;
                }


            }



            if (startPos.y < 0 && bs.GetComponent<battleSystemAi>().state == gameState.p2Turn)
            {
                Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, range);
                foreach (Collider2D hit in hitColliders)
                {
                    if (hit.gameObject.tag == "p2")
                    {
                        check = true;
                        if (check)
                        {
                            transform.parent = hit.gameObject.transform;
                            poweredUp = true;
                            hit.gameObject.GetComponent<controllerballAi>().Power = 30;

                        }
                        break;



                    }



                }

                if (!check)
                {
                    transform.position = originalPos;
                }


            }
        }

    }
}
