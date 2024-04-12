using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PreCameraPosition : MonoBehaviour
{
    // Start is called before the first frame update
    public int Index;
    public List<Vector2> PositionList = new();

    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(MoveCamera(PositionList[Index], 300));
            Index++;
        }
        if (Index == PositionList.Count)
        {
            Index = 0;
        }
    }

    IEnumerator MoveCamera(Vector2 targetPosition, int frame)
    {
        for (int i = 0; i < frame; i++)
        {
            transform.position += new Vector3(
                (targetPosition.x - transform.position.x) / frame,
                (targetPosition.y - transform.position.y) / frame,
                0
            );
            yield return null;
        }
    }
}
