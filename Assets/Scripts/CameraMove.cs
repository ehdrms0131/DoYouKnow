using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform target;
    public Camera camera;

    [SerializeField]
    private float lookSensitivity = 1;
    private float cameraRotatelimit = 45; //최대 카메라 각도
    private float currentCameraRotation; //현재 카메라 각도



    private void Start()
    {
        camera = FindObjectOfType<Camera>();   
    }
    private void Update()
    {
        CameraRotate();
        Follow();
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
        camera.transform.rotation = Quaternion.Euler(currentCameraRotation, 0f, 0f);
        //z값 고정 Quaternion xyz w
        //euler값을 쓰는 이유: Gimbal Lock (z축의 변환,고정)

        //r=ro+vt

        //rotate.x = Mathf.Clamp(rotate.x, -90.0f, 90.0f);//각도를 제한
        return;
    }
    void Follow()
    {
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
        return;
    }
}
