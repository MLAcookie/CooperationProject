using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBackTo : MonoBehaviour
{
    public string SceneName;
    public GameObject Animation;

    private void Awake()
    {
        GetComponent<Button>()
            .onClick.AddListener(() =>
            {
                Animation.GetComponent<CloudAnimation>().SceneName = SceneName;
                Animation.GetComponent<CloudAnimation>().ShowAnimation();
            });
    }
}
