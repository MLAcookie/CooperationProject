using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButonClickTest : MonoBehaviour
{
    public void ClickCallBackTest()
    {
        Debug.Log("1111");
    }

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ClickCallBackTest);
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
