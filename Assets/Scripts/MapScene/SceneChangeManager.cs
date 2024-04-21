using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeManager : MonoBehaviour
{
    public static SceneChangeManager instance;
    public static GameObject Animation;
    public GameObject AAA;

    private void Awake()
    {
        Animation = AAA;
    }
    public void ChangeSceneWithAnimation(string name)
    {
        if(Animation == null)
        {
            Debug.Log("Null");
        }
        Animation.GetComponent<CloudAnimation>().SceneName = name;
        Animation.GetComponent<CloudAnimation>().ShowAnimation();
    }
}
