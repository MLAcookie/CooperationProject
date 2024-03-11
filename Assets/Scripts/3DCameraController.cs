using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("主相机")]
    public Transform maincamera;

    [Header("目标")]
    public Transform target;//目标
    public float direction = 10.0f;//距离
    public float mindirection = 5.0f;//最小距离
    public float maxdirection = 20.0f;//最大距离
    public bool isSmoothDire = true;
    public float directionSpeed = 10.0f;//距离控制灵敏度
    public float directionTime = 0.4f;//距离变化所需时间
    private float directionVelocity = 0.0f;
    private float currentdirection;

    [Header("镜头画面")]
    public float size = 5;//画面尺寸
    public float maxsize = 5;//最大画面尺寸
    public float minsize = 5;//最小画面尺寸
    public bool isSmoothSize = true;
    public bool isOrthographic = true;//是否为正交相机
    [Range(1, 179)] public int FOV = 60;//相机FOV

    [Header("镜头旋转")]
    public float elevation = 210.0f;//摄像机仰角
    public bool isSmoothRota = true;
    public float rotationTime = 0.2f;//旋转变化所需时间
    private Quaternion targetQuaternion;
    private float yVelocity = 0.0f;
    private float targetRotx, targetRoty, targetRotz = 0;

    [Header("镜头移动")]
    public bool LockCameraPosition = false;//相机锁
    public bool isSmoothMove = true;
    public float moveTime = 0.5f; //平滑移动所需时间
    private Vector3 cameraVelocity = Vector3.zero;
    private float offsetx, offsety, offsetz = 0;

    [Header("镜头震动")]
    public float shakeDuration = 0.5f;//震动时间
    public float shakeAmplitude = 0.1f;//震动幅度
    public float shakeFrequency = 1.0f;//震动频率
    public bool isShake = false;
    private float shakeTimer = 0.0f;
    private float shakeFix = 0.0f;

    void Start()
    {
        //maincamera = GetComponentInChildren<Transform>();
        currentdirection = direction;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            targetRoty -= 45;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            targetRoty += 45;
        }
        float directionAmount = Input.GetAxis("Mouse ScrollWheel") * directionSpeed;
        if (Input.GetKey(KeyCode.I))
        {
            size += 0.1f;
        }
        if (Input.GetKey(KeyCode.O))
        {
            size -= 0.1f;
        }
        if (directionAmount != 0)
        {
            direction = Mathf.Clamp(direction - directionAmount, mindirection, maxdirection);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            CameShake();
        }
    }

    void LateUpdate()
    {//使用这个更新方法就是保证每帧刷新时，物体先变化，然后摄像机才跟随的
        if (!target)
            return;//安全保护
        CameRotate();
        CameMove();
        CameSize();
        CameLookAt();
        CameShake();
        AvoidCrossWall();
    }

    private void CameRotate()
    {
        if (isSmoothRota)
        {
            targetQuaternion = Quaternion.Euler(new Vector3(targetRotx,
            targetRoty, targetRotz));
            float yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                targetQuaternion.eulerAngles.y,
                ref yVelocity, rotationTime);
            transform.rotation = Quaternion.Euler(0, yAngle, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(targetRotx,
            targetRoty, targetRotz));
        }
        
    }//镜头旋转

    private void CameMove()
    {
        if (isSmoothMove)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position,
            ref cameraVelocity, moveTime);
        }
        else
        {
            transform.position = target.position;
        }
        if (!maincamera.GetComponent<Camera>().orthographic)
        {
            if (isSmoothDire)
            {
                currentdirection = Mathf.SmoothDamp(currentdirection, direction,
                    ref directionVelocity, directionTime);
            }
            else
            {
                currentdirection = direction;
            }
        }
        offsetz = currentdirection * Mathf.Cos(Mathf.Deg2Rad * elevation);
        offsety = -1 * currentdirection * Mathf.Sin(Mathf.Deg2Rad * elevation);
        maincamera.localPosition = new Vector3(offsetx, offsety, offsetz);
    }//镜头移动

    private void CameSize()
    {
        if (maincamera.GetComponent<Camera>().orthographic)
        {
            size = direction;
            Camera.main.orthographicSize = size;
        }
        else
        {
            Camera.main.fieldOfView = FOV;
        }
    }//镜头尺寸

    private void CameLookAt()
    {
        maincamera.LookAt(transform.position);
    }//镜头朝向

    private void CameShake()
    {
        if (shakeTimer > 0.0f)
        {
            isShake = true;
            if(shakeFix >= shakeFrequency)
            {
                Vector3 shakePosition = Random.insideUnitSphere * shakeAmplitude;
                transform.localPosition = maincamera.position + shakePosition;
                shakeFix = 0.0f;
            }
            else
            {
                shakeFix += Time.deltaTime;
            }
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            isShake = false;
            shakeTimer = 0.0f;
        }
    }

    private void AvoidCrossWall()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, maincamera.position - transform.position, out hit))
        {
            if (hit.collider.tag == "Road")
                direction = (hit.transform.position - transform.position).magnitude - 1.0f;
        }
    }//防穿墙
}