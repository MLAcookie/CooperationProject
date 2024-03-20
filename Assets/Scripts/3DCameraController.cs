using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3DController : MonoBehaviour
{
    //���ýű����ص�һ���������ϣ�������ϵ��ÿ���������Ϊ�����岢��Transform����Ϊ0

    [Header("�����")]
    public Transform maincamera;//��Ϊ����������

    [Header("Ŀ��")]
    public Transform target;//����Ŀ��
    public float direction = 10.0f;//����
    public float mindirection = 5.0f;//��С����
    public float maxdirection = 20.0f;//������
    public bool isSmoothDire = true;
    public float directionSpeed = 10.0f;//�������������
    public float directionTime = 0.4f;//����仯����ʱ��
    private float directionVelocity = 0.0f;
    private float currentdirection;

    [Header("��ͷ����")]
    public float size = 5;//����ߴ�
    public float maxsize = 5;//�����ߴ�
    public float minsize = 5;//��С����ߴ�
    public bool isSmoothSize = true;
    public bool isOrthographic = true;//�Ƿ�Ϊ�������
    [Range(1, 179)] public int FOV = 60;//���FOV

    [Header("��ͷ��ת")]
    public float elevation = 210.0f;//���������
    public bool isSmoothRota = true;
    public float rotationTime = 0.2f;//��ת�仯����ʱ��
    private Quaternion targetQuaternion;
    private float yVelocity = 0.0f;
    private float targetRotx, targetRoty, targetRotz = 0;

    [Header("��ͷ�ƶ�")]
    public bool LockCameraPosition = false;//�����
    public bool isSmoothMove = true;
    public float moveTime = 0.5f; //ƽ���ƶ�����ʱ��
    private Vector3 cameraVelocity = Vector3.zero;
    private float offsetx, offsety, offsetz = 0;

    [Header("��ͷ��")]
    public float shakeDuration = 0.5f;//��ʱ��
    public float shakeAmplitude = 0.1f;//�𶯷���
    public float shakeFrequency = 1.0f;//��Ƶ��
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
            //�����𶯣������޸�
            //CameShake();
        }
    }

    void LateUpdate()
    {//ʹ��������·������Ǳ�֤ÿ֡ˢ��ʱ�������ȱ仯��Ȼ��������Ÿ����
        if (!target)
            return;//��ȫ����
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
        
    }//��ͷ��ת

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
    }//��ͷ�ƶ�

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
    }//��ͷ�ߴ�

    private void CameLookAt()
    {
        maincamera.LookAt(transform.position);
    }//��ͷ����

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
    }//����ǽ
}