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
        transform.position = new Vector3(target.position.x, target.position.y,target.position.z);
    }
    void CameraRotate()
    {
        float rotateSpeed = 150f;
        //마우스 입력받기
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        //회전 방향 결정
        Vector3 dir = new Vector3(-mouseY, mouseX , 0);
        dir.Normalize();
        //dir = Camera.main.transform.TransformDirection(dir);
        //r=ro+vt
        transform.eulerAngles += dir * rotateSpeed * Time.deltaTime;

        Vector3 rotate = transform.eulerAngles;
        rotate.x = Mathf.Clamp(rotate.x, -90.0f, 90.0f);//각도를 제한
        transform.eulerAngles = rotate;
    }
}
