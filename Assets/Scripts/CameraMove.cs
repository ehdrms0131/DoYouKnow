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
        Vector3 dir = new Vector3(-mouseY, mouseX, 0);
        dir = Camera.main.transform.TransformDirection(dir);
        //Mathf.Clamp
        //r=ro+vt
        transform.eulerAngles += dir * rotateSpeed * Time.deltaTime;
    }
}
