using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReservesCount : MonoBehaviour
{
    public WaterCup WaterCupInfo;
    public GameObject resrvesPos;

    private Text text;

    void Start()
    {
        WaterCupGameEvent.instance.onFinishPouring += refresh;
        text = gameObject.GetComponent<Text>();
        text.text = WaterCupInfo.reserves.ToString();
        refresh();
        WaterCupGameEvent.instance.textInitial(gameObject);
    }

    void Update()
    {
        transform.position = resrvesPos.transform.position;
    }

    private void refresh()
    {
        text.text = WaterCupInfo.reserves.ToString() + "/" + WaterCupInfo.maxReserves.ToString();
        if (WaterCupInfo.reserves == WaterCupInfo.maxReserves)
        {
            text.color = new Color(.8f, 0, 0);
        }
        else
        {
            text.color = new Color(0, .8f, 0);
        }
    }
}
