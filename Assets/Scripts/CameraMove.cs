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
        Follow();
    }
    void CameraRotate()
    {
        //float rotatelimit = 60.0f;

        //마우스 입력받기
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        //회전 방향/각도 결정
        mouseX += Time.deltaTime * 10;
        mouseY += Time.deltaTime * 10;
        //my = Mathf.Clamp(my, -rotatelimit, rotatelimit);

        // 쿼터니언 오일러 사용 방법  
        transform.rotation = Quaternion.Euler(mouseX, mouseY, 0.0f);
        //z값 고정 Quaternion xyz w
        //euler값을 쓰는 이유: Gimbal Lock (z축의 변환,고정)

        //r=ro+vt

        //rotate.x = Mathf.Clamp(rotate.x, -90.0f, 90.0f);//각도를 제한
        return;
    }
    void Follow()
    {
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
    }
}
