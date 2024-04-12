using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PersonUI : MonoBehaviour
{
    public GameObject person;
    public void changedperson()
    {
         person.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
    }
}
