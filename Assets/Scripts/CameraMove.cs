using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform target;

    public Camera camera;

    [SerializeField]
    private float lookSensitivity = 1;
    private float cameraRotatelimit = 40; //최대 카메라 각도
    private float currentCameraRotation = 0; //현재 카메라 각도


    private void Start()
    {
        camera = FindObjectOfType<Camera>();   
    }
    private void Update()
    {
        Follow();
    }
    private void LateUpdate()
    {
        CameraRotate();
    }
    void CameraRotate()
    {
        //float rotatelimit = 60.0f;

        //마우스 입력받기
        float mouseX = Input.GetAxis("Mouse X");

        float mouseY = Input.GetAxis("Mouse Y");

        float cameraRotate = mouseY * lookSensitivity;
        //회전 방향/각도 결정
        //mouseX += Time.deltaTime * 10;
        //mouseY += Time.deltaTime * 10; //0.016

        

        currentCameraRotation -= cameraRotate;
        currentCameraRotation = Mathf.Clamp(currentCameraRotation, -cameraRotatelimit, cameraRotatelimit);

        // 쿼터니언 오일러 사용 방법  

        camera.transform.rotation = Quaternion.Euler(currentCameraRotation, 0f, 0f);//y축이동

        //z값 고정 Quaternion xyz w
        //euler값을 쓰는 이유: Gimbal Lock (z축의 변환,고정)

        //r=ro+vt

        //rotate.x = Mathf.Clamp(rotate.x, -90.0f, 90.0f);//각도를 제한

        /*
        // Compute the position the object will reach
        // 개체가 도달하는 위치를 계산합니다.
        Vector3 desiredPosition = Target.rotation * (Target.position + Offset);

        // Compute the direction the object will look at
        // 객체가 볼 방향을 계산합니다.
        Vector3 desiredDirection = Vector3.Project( Target.forward, (Target.position - desiredPosition).normalized );

        // Rotate the object
        // 객체 회전
        transform.rotation = Quaternion.Slerp( transform.rotation, Quaternion.LookRotation( desiredDirection ), Time.deltaTime * Speed );


        // Place the object to "compensate" the rotation
        // 회전 "보정"을 위해 객체를 배치합니다.
        transform.position = Target.position - transform.forward * Offset.magnitude;
        */
        return;
    }
    void Follow()
    {
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
        return;
    }

}
