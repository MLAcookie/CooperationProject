using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutLine : MonoBehaviour
{

    LineRenderer line;
    Vector2 startPoint;
    Vector2 endPoint;


    bool isDraw = false;
    bool isDrag = false;

    List<GameObject> cutObjects = new List<GameObject>();
    public float moveDistance = 0.2f;


    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isDraw == false)
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.tag == "Field")
            {
                Debug.Log("touch");
                isDrag = true;
            }
            else
            if (isDrag == false)
            {
                line.positionCount = 0;
                isDraw = true;
                startPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                line.positionCount = 2;
                line.SetPosition(0, startPoint);
            }


        }

        if (Input.GetMouseButton(0))
        {
            if(isDraw)
            {
                endPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
                line.SetPosition(1, endPoint);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isDraw == true)
            {
                line.positionCount = 0;
                isDraw = false;

                FieldGameEvent.instance.Cutting();

                cutObjects.Clear();

            }
            isDrag = false;
        }
    }


}
