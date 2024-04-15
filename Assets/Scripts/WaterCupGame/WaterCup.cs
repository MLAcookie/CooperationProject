using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCup : MonoBehaviour
{
    private Vector2 mousePos;
    private Vector2 distance;
    public Vector2 originPos;

    private bool inBack = false;
    private bool endPour = true;
    public int maxReserves = 0;
    public int reserves = 0;

    public int level = 0;
    public int ID = 0;
    public int goalReserves = 0;


    Rigidbody2D rigid;
    SpriteRenderer spr;

    public Sprite k1;
    public Sprite k2;
    public Sprite k3;
    public Sprite k4;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        spr = gameObject.GetComponent<SpriteRenderer>();
        originPos = gameObject.transform.position;


        WaterCupGameEvent.instance.onFinishPouring += refresh;
        refresh();
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (inBack == true)
        {
            //�϶�����Զ���λ
            gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, originPos, Time.deltaTime * 3);
            if(Vector2.Distance(gameObject.transform.position, originPos) <= 0.1f)
            {
                inBack = false;
                spr.sortingLayerName = "notOnChoose";
            }
        }

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
        inBack = true;
        endPour = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.tag == "WaterCup")
            {

                if (inBack == true)
                {
                    WaterCup ot = collision.GetComponent<WaterCup>();
                    if (reserves > 0 && endPour == false)
                    {
                        //ˮ��������0
                        if (ot.maxReserves - ot.reserves > 0)
                        {
                            //Ŀ��ˮ����δ��
                            if (reserves >= ot.maxReserves - ot.reserves)
                            {
                                //ˮ��������Ŀ��ʣ��ռ�
                                reserves += ot.reserves;
                                reserves -= ot.maxReserves;
                                ot.reserves = ot.maxReserves;
                            }
                            else
                            {
                                //ˮ����С��Ŀ��ʣ��ռ�
                                ot.reserves += reserves;
                                reserves = 0;
                            }
                            WaterCupGameEvent.instance.FinishPouring();
                        }
                    }
                    endPour = true;
                }
            }

        }
    }
    

    public void setWaterCupValue(int max,int present)
    {
        maxReserves = max;
        reserves = present;
    }
    public void setWaterCupValue(int max)
    {
        maxReserves = max;
        reserves = 0;
    }

    public void refresh()
    {
        if (ID != -1)
        {
            Debug.Log(level + "  " + ID);
            if (reserves == goalReserves)
            {
                WaterCupGameEvent.instance.CupAction(level, ID, true);
            }
            else
            {
                WaterCupGameEvent.instance.CupAction(level, ID, false);
            }
        }
        if (reserves == 0)
        {
            spr.sprite = k1;
        }
        else if(reserves <= maxReserves/2)
        {
            spr.sprite = k2;
        }
        else if (reserves < maxReserves)
        {
            spr.sprite = k3;
        }
        else if (reserves == maxReserves)
        {
            spr.sprite = k4;
        }
    }

}