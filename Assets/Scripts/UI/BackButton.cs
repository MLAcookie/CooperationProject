using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public string beforeScene = "StartScene";
    public void OnButtonClick()
    {
        SceneManager.LoadScene(beforeScene);
    }
}
