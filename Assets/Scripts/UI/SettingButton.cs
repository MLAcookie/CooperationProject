using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour
{
    public GameObject Panel_Settings;

    void Start()
    {}

    void Update()
    {}

    public void OnButtonClick()
    {
        Panel_Settings.SetActive(true);
        Panel_Settings.GetComponent<SettingPanel>().Init();
    }
}
