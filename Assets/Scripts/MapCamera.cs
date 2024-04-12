using UnityEngine;

public class MapCamera : MonoBehaviour
{
    private Vector3 lastMousePosition;
    public float MapWidth = 0;
    public float MapHeight = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
            transform.position -= new Vector3(mouseDelta.x, mouseDelta.y, 0) * 0.02f;

            float height = Camera.main.orthographicSize * 2f;
            float width = height * Camera.main.aspect;
            float aX = Mathf.Abs(MapWidth - width) / 2.0f;
            float aY = Mathf.Abs(MapHeight - height)/2.0f;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -aX, aX), Mathf.Clamp(transform.position.y, -aY, aY), transform.position.z);

            lastMousePosition = Input.mousePosition;
        }
    }
}