using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GlobalVariables.instance.BGMVolume = .4f;
        GlobalVariables.instance.volumeChanged = true;
    }
}
