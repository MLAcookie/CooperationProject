using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public GameObject Map;

    private Transform mapTransform;
    private SpriteRenderer mapSpriteRenderer;

    private Camera thisCamera;

    private Vector2 offset;
    private Vector2 from;
    private Vector2 to;

    private Vector2 first = Vector2.zero; //鼠标第一次落下点
    private Vector2 second = Vector2.zero; //鼠标第二次位置（拖拽位置）
    private Vector3 vecPos = Vector3.zero;
    private bool IsNeedMove = false; //是否需要移动

    // Start is called before the first frame update
    void Awake()
    {
        first.x = transform.position.x; //初始化
        first.y = transform.position.y;

        mapTransform = Map.GetComponent<Transform>();
        mapSpriteRenderer = mapTransform.GetComponent<SpriteRenderer>();

        thisCamera = GetComponent<Camera>();

        offset = new Vector2(
            Mathf.Abs(mapSpriteRenderer.bounds.size.x) / 2
                - thisCamera.orthographicSize * Screen.width / Screen.height,
            Mathf.Abs(mapSpriteRenderer.bounds.size.y) / 2 - thisCamera.orthographicSize
        );

        from = new Vector2(mapTransform.position.x - offset.x, mapTransform.position.y - offset.y);
        to = new Vector2(mapTransform.position.x + offset.x, mapTransform.position.y + offset.y);
    }

    private void OnGUI()
    {
        if (Event.current.type == EventType.MouseDown)
        {
            //记录鼠标按下的位置
            first = Event.current.mousePosition;
        }
        if (Event.current.type == EventType.MouseDrag)
        {
            //记录鼠标拖动的位置
            second = Event.current.mousePosition;
            Vector3 fir = Camera.main.ScreenToWorldPoint(new Vector3(first.x, first.y, 0)); //转换至世界坐标
            Vector3 sec = Camera.main.ScreenToWorldPoint(new Vector3(second.x, second.y, 0));
            vecPos = sec - fir; //需要移动的 向量
            first = second;
            IsNeedMove = true;
        }
        else
        {
            IsNeedMove = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsNeedMove == false)
        {
            return;
        }
        var x = transform.position.x;
        var y = transform.position.y;
        x -= vecPos.x; //向量偏移
        y += vecPos.y;
        //限制摄像机移动
        x = Mathf.Clamp(x, from.x, to.x);
        y = Mathf.Clamp(y, from.y, to.y);
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
