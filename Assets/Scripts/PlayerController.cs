using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed = 1.5f;
    float x;
    float z;
    private Vector3 moving;
    Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Rotate();
        Jump();
    }
    void Move()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        moving = new Vector3(x, 0, z).normalized;//normalized는 벡터값을 1로 평준화해준다
        transform.position += moving * playerSpeed * Time.deltaTime;
        transform.LookAt(transform.position,moving);
        return;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))//스페이스바
        {
            rigid.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            return;
        }
    }
    void Rotate()
    {
        float rotateSpeed = 300f;
        //마우스 입력받기
        float mouseX = Input.GetAxis("Mouse X");
        //회전 방향 결정
        Vector3 dir = new Vector3(0, -mouseX, 0);

        //r=ro+vt
        transform.eulerAngles += dir * rotateSpeed * Time.deltaTime;
        return;
    }
}
