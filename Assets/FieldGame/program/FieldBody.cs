using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBody : MonoBehaviour
{
    private Vector2 mousePos;
    private Vector2 distance;

    public GameObject fi_part;

    Rigidbody2D rigid;
    SpriteRenderer spr;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        spr = gameObject.GetComponent<SpriteRenderer>();

        FieldGameEvent.instance.onCut += onCutting;
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


    }

    private void OnMouseDown()
    {
        distance = new Vector2(transform.position.x, transform.position.y) - mousePos;
        spr.sortingLayerName = "onChoose";
    }

    private void OnMouseDrag()
    {
        transform.position = mousePos + distance;
        rigid.velocity = Vector2.zero;
    }

    private void OnMouseUp()
    {
        spr.sortingLayerName = "notOnChoose";
    }

    void onCutting()
    {
        Instantiate(fi_part, transform.position + new Vector3(-3f,0,0), transform.rotation);
        FieldGameEvent.instance.onCut -= onCutting;
        Destroy(gameObject);
    }
}
