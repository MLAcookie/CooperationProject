using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class pen : MonoBehaviour
{
    public static pen instance;

    public Camera real;
    public Camera mainCamera;
    public float speed = 15;

    public GameObject p;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (real == null)
        {
            var search = GameObject.Find("Main Camera");
            if (search != null)
            {
                real = search.GetComponent<Camera>();
            }
            else
            {
                Debug.Log("error");
            }
        }
    }
    void Start()
    {
        FieldGameEvent.instance.onStartCut += startDraw;
        FieldGameEvent.instance.onEndCut += endDraw;
        transform.position = new Vector3(0, 0, 0);
        mainCamera = real;
    }


    private void startDraw()
    {
        p.SetActive(true);
    }

    private void endDraw()
    {
        p.SetActive(false);
    }

    private void FixedUpdate()
    {
        Vector3 mos_pos = real.ScreenToWorldPoint(Input.mousePosition);
        Vector3 point_pos = transform.position;


        // 获取鼠标位置
        Vector3 mousePosition = Input.mousePosition;

        // 将鼠标位置从屏幕坐标转换为世界坐标
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, mainCamera.transform.position.y));

        // 将鼠标位置限制在摄像机范围内
        worldPosition.x = Mathf.Clamp(worldPosition.x, mainCamera.transform.position.x - mainCamera.orthographicSize * mainCamera.aspect, mainCamera.transform.position.x + mainCamera.orthographicSize * mainCamera.aspect);
        worldPosition.y = Mathf.Clamp(worldPosition.y, mainCamera.transform.position.y - mainCamera.orthographicSize, mainCamera.transform.position.y + mainCamera.orthographicSize);
        worldPosition.z = 0;
            
        // 更新鼠标位置
        transform.position = worldPosition;

    }

}