using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClicShowUI : MonoBehaviour
{
    public GameObject UIObject;

    Button localButton;

    void ShowUI()
    {
        UIObject.SetActive(true);
    }

    private void Awake()
    {
        localButton = GetComponent<Button>();
        localButton.onClick.AddListener(ShowUI);
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
