using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    
    private void Update()
    {
        CameraRotate();
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
    }
    void CameraRotate()
    {
        //float rotatelimit = 60.0f;
        //마우스 입력받기
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        //회전 방향 결정
        //mx += mouseX * rotateSpeed * Time.deltaTime;
        //my += mouseY * rotateSpeed * Time.deltaTime;
        //my = Mathf.Clamp(my, -rotatelimit, rotatelimit);


        transform.rotation = Quaternion.Euler(mouseX, mouseY, 0.0f);
        //r=ro+vt

        //transform.eulerAngles += dir * rotateSpeed * Time.deltaTime;
        ////transform.eulerAngles = new Vector3(-my, mx, 0);
        


        //Vector3 rotate = transform.eulerAngles;
        ////rotate.x = Mathf.Clamp(rotate.x, -90.0f, 90.0f);//각도를 제한
        //rotate.y = Mathf.Clamp(-90.0f, rotate.y, 90.0f);//각도를 제한
        //rotate.x = Mathf.Clamp(rotate.x, -90.0f, 90.0f);//각도를 제한
        //transform.eulerAngles = rotate;
    }
}
