using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBody : MonoBehaviour
{
    public GameObject fi_part;
    public Vector3 offset;
    void Start()
    {
        FieldGameEvent.instance.onEndCut += onCutting;
    }

    void Update()
    {

    }

    void onCutting()
    {
        fi_part.SetActive(true);
        fi_part.transform.position = transform.position + offset;
        fi_part.transform.rotation = transform.rotation;
        FieldGameEvent.instance.onEndCut -= onCutting;
        gameObject.SetActive(false);
    }
}
