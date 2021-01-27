using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;

    public Camera cameraX;
    public Camera cameraY;

    [SerializeField]
    private float XlookSensitivity = 1.95f;     //1.3~2.3 (감도)
    private float XcameraRotatelimit = 70f;     //최대 카메라 각도
    private float XcurrentCameraRotation = 0f;  //현재 카메라 각도
    private float YlookSensitivity = 1f;        //0.75~1.25;
    private float YcameraRotatelimit = 80f;     //최대 카메라 각도
    private float YcurrentCameraRotation = 0f;  //현재 카메라 각도

    private void Start()
    {
        cameraX = FindObjectOfType<Camera>();
        cameraY = FindObjectOfType<Camera>();
    }
    private void Update()
    {
        //CameraRotate();
        CameraUpDown();
        CameraRotate();
        Follow();
        //회전 상하,좌우 순서 내일 물어보기
    }
    void CameraRotate()
    {
        //float mouseX = Input.GetAxis("Mouse X");
        float mouseX = Input.GetAxis("Mouse X");
        float XcameraRotate = mouseX * XlookSensitivity;
        XcurrentCameraRotation -= XcameraRotate;
        XcurrentCameraRotation = Mathf.Clamp(XcurrentCameraRotation, -XcameraRotatelimit, XcameraRotatelimit);
        cameraX.transform.rotation = Quaternion.Euler(0f, -XcurrentCameraRotation, 0f); //y축이동
        //cam.MoveRotation(cam.rotation * Quaternion.Euler(rotation));
        return;
    }
    void CameraUpDown()
    {
        //마우스 입력받기  
        float mouseY = Input.GetAxis("Mouse Y");
        float YcameraRotate = mouseY * YlookSensitivity;
        //회전 방향/각도 결정
        //mouseX += Time.deltaTime * 10;
        //mouseY += Time.deltaTime * 10; //0.016
        YcurrentCameraRotation -= YcameraRotate;
        YcurrentCameraRotation = Mathf.Clamp(YcurrentCameraRotation, -YcameraRotatelimit, YcameraRotatelimit);
        // 쿼터니언 오일러 사용 방법  
        cameraY.transform.rotation = Quaternion.Euler(YcurrentCameraRotation, 0f, 0f);  //y축이동
        //z값 고정 Quaternion xyz w
        //euler값을 쓰는 이유: Gimbal Lock (z축의 변환,고정)
        //r=ro+vt
        //rotate.x = Mathf.Clamp(rotate.x, -90.0f, 90.0f);  //각도를 제한
        return;
    }
    void Follow()
    {
        transform.position = new Vector3(target.position.x * 1.1f, target.position.y * 1.1f, target.position.z);//카메라 궤도
        return;
    }
}
