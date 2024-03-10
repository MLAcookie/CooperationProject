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
    


    Rigidbody2D rigid;
    SpriteRenderer spr;

    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        spr = gameObject.GetComponent<SpriteRenderer>();
        originPos = gameObject.transform.position;
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (inBack == true)
        {
            //拖动完后自动归位
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

    //private void OnMouseUpAsButton()
    //{

    //}

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
                        //水储量大于0
                        if (ot.maxReserves - ot.reserves > 0)
                        {
                            //目标水储量未满
                            if (reserves >= ot.maxReserves - ot.reserves)
                            {
                                //水储量大于目标剩余空间
                                reserves += ot.reserves;
                                reserves -= ot.maxReserves;
                                ot.reserves = ot.maxReserves;
                            }
                            else
                            {
                                //水储量小于目标剩余空间
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


}
