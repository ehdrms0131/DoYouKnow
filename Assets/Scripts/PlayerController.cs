using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    public float playerSpeed = 1.5f;
    float x;
    float z;
    private Vector3 moving;

    Rigidbody playerRigid;
    Animator animator;


    [SerializeField]
    private float lookSensitivity = 1.95f;     //1.3~2.3 (감도)
    private float Rotatelimit = 70f;     //최대 카메라 각도
    private float Rotation = 0f;  //현재 카메라 각도
    private void Awake()
    {
        playerRigid = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Move();
        Rotate();
        Jump();
    }
    void Move()
    {
        x = Input.GetAxisRaw("Horizontal"); //0,1
        z = Input.GetAxisRaw("Vertical");
        moving = new Vector3(x, 0, z).normalized;//normalized는 벡터값을 1로 평준화해준다
        transform.position += moving * playerSpeed * Time.deltaTime;
        //transform.LookAt(transform.position, moving);

        animator.SetBool("IsWalk", moving != Vector3.zero);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))//스페이스바
        {
            playerRigid.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            return;
        }
    }
    void Rotate()
    {
        //float rotateSpeed = 300f;
        ////마우스 입력받기
        //float mouseX = Input.GetAxis("Mouse X");
        ////회전 방향 결정
        //Vector3 dir = new Vector3(0, mouseX, 0);//캐릭터 방향

        ////r=ro+vt
        //transform.eulerAngles += dir * rotateSpeed * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X");
        float rotate = mouseX * lookSensitivity;
        Rotation -= rotate;
        Rotation = Mathf.Clamp(Rotation, -Rotatelimit, Rotatelimit);
        transform.rotation = Quaternion.Euler(0f, -Rotation, 0f); //y축이동
        //cam.MoveRotation(cam.rotation * Quaternion.Euler(rotation));
        
        return;
    }
    void CameraRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");

        //float cameraRotate = mouseX * lookSensitivity;
        Vector3 rotation = new Vector3(0f, mouseX, 0f) * 1;

        playerRigid.MoveRotation(playerRigid.rotation * Quaternion.Euler(rotation));

        return;
    }
}
