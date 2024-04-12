using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin,
                ray.direction,
                Mathf.Infinity);
            if (hit.collider != null &&
                hit.collider.gameObject == this.gameObject)
            {
                DialogBoxManager.instance.OpenDiglogBox("01", 0);
            }
        }
    }
}
