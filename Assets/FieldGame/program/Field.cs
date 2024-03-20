using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private Vector2 mousePos;
    private Vector2 distance;

    public GameObject endPos;
    //��һ��ƴͼ����װ�ڵ�
    private Vector2 otherPartPos;

    private float adsorbDistance = 0.4f;

    Rigidbody2D rigid;
    SpriteRenderer spr;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        spr = gameObject.GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //ʵʱ��ȡ���սڵ��λ��

        otherPartPos = endPos.transform.position;
        //���ڣ�ֱ�ӻ�ȡ��һ��ƴͼ���λ��

    }

    private void OnMouseDown()
    {
        distance = new Vector2(transform.position.x, transform.position.y) - mousePos;
        spr.sortingLayerName = "onChoose";
    }

    private void OnMouseDrag()
    {
        if (Vector2.Distance(mousePos + distance, otherPartPos) <= adsorbDistance)
        {
            transform.position = otherPartPos;
        }
        else
        {
            transform.position = mousePos + distance;
        }
        rigid.velocity = Vector2.zero;
    }

    private void OnMouseUp()
    {
        if (Vector2.Distance(transform.position, otherPartPos) <= adsorbDistance)
        {
            transform.position = otherPartPos;
            FieldGameEvent.instance.gameFinish();
            Debug.Log("end");
        }
        spr.sortingLayerName = "notOnChoose";
    }
}
