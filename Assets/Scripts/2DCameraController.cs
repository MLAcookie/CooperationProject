using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2DController : MonoBehaviour
{
    public float cameraSpeed = 2.0f;
    public float mouseXRange = 20.0f;
    private float mouseX;
    private float mouseY;
    void Start()
    {
        
    }

    void Update()
    {
        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;
        if (mouseX < mouseXRange)
        {
            transform.position += Vector3.left * cameraSpeed * Time.deltaTime;
        }
        else if (mouseX > Screen.width - mouseXRange)
        {
            transform.position += Vector3.right * cameraSpeed * Time.deltaTime;
        }
    }
}
