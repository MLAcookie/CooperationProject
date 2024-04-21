using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAudioPlay : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
