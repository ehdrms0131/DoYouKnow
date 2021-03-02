using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove_ver2 : MonoBehaviour
{
    [Header("카메라, 위치. 각도, Fov")]
    [SerializeField] Vector3 position = new Vector3(0, 3.6f, -7.8f);
    [SerializeField] Vector3 rotation = new Vector3(14, 0, 0);
    [SerializeField] [Range(0, 100)] float fov = 40f;

    [Header("카메라 이동 및 회전 속도")]
    [SerializeField] float moveSpeed = 50f;
    [SerializeField] float turnSpeed = 10f;

    Transform target;
    Transform cam;
    Transform ch24;
    // Start is called before the first frame update

    void Start()
    {
        target = GameObject.Find("Ch24").transform;
        InitCamera();
    }

    void InitCamera()
    {
        //카메라 설정
        cam = Camera.main.transform;
        cam.GetComponent<Camera>().fieldOfView = fov;
        //피벗 오브젝트 생성
        ch24 = new GameObject("Pivot").transform;
        ch24.position = target.position;

        cam.parent = ch24;
        cam.localPosition = position;
        cam.localRotation = Quaternion.Euler(rotation);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = target.position;
        Quaternion rot = target.rotation;

        ch24.position = Vector3.Lerp(ch24.position, pos, moveSpeed * Time.deltaTime);
        ch24.rotation = Quaternion.Lerp(ch24.rotation, rot, turnSpeed * Time.deltaTime);

    }

    private void LateUpdate()
    {
    
    }
}
