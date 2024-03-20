using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject clickedObject;
    public GameObject Panel_Settings;

    /*void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!Panel_Settings.activeInHierarchy)
            {
                SceneManager.LoadScene("MainScene");
            }
        }
    }*/
    public void OnButtonClick()
    {
        if(!Panel_Settings.active)
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}