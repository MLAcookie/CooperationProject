using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Field : MonoBehaviour
{
    private Vector2 mousePos;
    private Vector2 distance;

    public List<GameObject> endPos = new List<GameObject>();
    //��һ��ƴͼ����װ�ڵ�
    private List<Vector2> otherPartPos = new List<Vector2>();


    public int id;
    public int goal;
    public int level;




    private float adsorbDistance = 0.4f;

    Rigidbody2D rigid;
    SpriteRenderer spr;


    public List<int> neID;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        spr = gameObject.GetComponent<SpriteRenderer>();

        FieldGameEvent.instance.onReturnPoint += SetPoint;

    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //ʵʱ��ȡ���սڵ��λ��

        if (neID.Count != 0)
        {
            for (int i = 0; i < neID.Count; i++)
            {
                FieldGameEvent.instance.findingPoint(neID[i]);
            }
        }
        //Ѱ�ҽڵ�

        if (endPos.Count != 0)
        {
            for (int i = 0; i < endPos.Count; i++)
            {
                otherPartPos[i] = endPos[i].transform.position;
            }
        }
        //��ȡ����

    }



    void SetPoint(int _id, GameObject point)
    {
        if(neID.Count != 0)
        {
            for (int i = 0; i < neID.Count; i++)
            {
                if (neID[i] == _id)
                {
                    endPos.Add(point);
                    otherPartPos.Add(endPos[i].transform.position);
                    neID.Remove(_id);
                }
            }
        }
    }



    private void OnMouseDown()
    {
        distance = new Vector2(transform.position.x, transform.position.y) - mousePos;
        if (id != -1)
        {
            FieldGameEvent.instance.FieldAction(level, goal, false);
        }
        spr.sortingLayerName = "onChoose";
    }

    private void OnMouseDrag()
    {
        if(endPos.Count == 0)
        {
            transform.position = mousePos + distance;
            rigid.velocity = Vector2.zero;
            if (Input.GetMouseButtonDown(1))
            {
                transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 90);
            }
        }
        else
        {
            for (int i = 0; i < endPos.Count; i++)
            {
                if (Vector2.Distance(mousePos + distance, otherPartPos[i]) <= adsorbDistance)
                {
                    transform.position = otherPartPos[i];
                }
                else
                {
                    transform.position = mousePos + distance;
                }
                rigid.velocity = Vector2.zero;
                if (Input.GetMouseButtonDown(1))
                {
                    transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 90);
                }
            }
        }
    }

    private void OnMouseUp()
    {
        if (id != -1)
        {
            for (int i = 0; i < endPos.Count; i++)
            {
                if (Vector2.Distance(transform.position, otherPartPos[i]) <= adsorbDistance)
                {
                    transform.position = otherPartPos[i];
                    FieldGameEvent.instance.FieldAction(level, goal, true);
                }
                spr.sortingLayerName = "notOnChoose";
            }
        }
    }
}
