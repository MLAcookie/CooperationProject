using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    public static float a;
    public static int b;
    
    public static SettingSave GetSettingModel()
    {
        return new SettingSave(a,b);
    }
    public static void SetSettingModel(SettingSave model)
    {
        a = model.a;
        b = model.b;
    }
}
