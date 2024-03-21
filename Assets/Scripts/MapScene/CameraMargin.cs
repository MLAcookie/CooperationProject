using UnityEngine;

public class CameraMargin : MonoBehaviour
{
    public GameObject Map;

    private Transform mapTransform;
    private Sprite mapSprite;

    private Camera thisCamera;

    private Vector2 offset;
    private Vector2 from;
    private Vector2 to;

    // Start is called before the first frame update
    void Start()
    {
        mapTransform = Map.GetComponent<Transform>();
        mapSprite = mapTransform.GetComponent<SpriteRenderer>().sprite;

        thisCamera = GetComponent<Camera>();

        offset = new Vector2(
            Mathf.Abs(mapSprite.vertices[0].x)
                - thisCamera.orthographicSize * Screen.width / Screen.height,
            Mathf.Abs(mapSprite.vertices[0].y) - thisCamera.orthographicSize
        );

        from = new Vector2(mapTransform.position.x - offset.x, mapTransform.position.y - offset.y);
        to = new Vector2(mapTransform.position.x + offset.x, mapTransform.position.y + offset.y);
    }

    // Update is called once per frame
    void Update() { }
}
