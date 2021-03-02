using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // 플레이어 w a s d 이동
    [SerializeField]
    private float _moveSpeed = 0f;
    private Rigidbody _rigid = null;
    private bool Ground_Check = false;

    //w w 대쉬
    private bool canRun = false;
    private float checkRun = 0.5f;

    //애니메이션
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        _rigid = GetComponent<Rigidbody>();

    }

    private void Dash(float moveSpeed)
    {
        transform.Translate(Vector3.forward * moveSpeed * (_moveSpeed / 5) * Time.deltaTime);
    }



    // Update is called once per frame
    void Update()
    {
        if (PlayerSkills.Instance.isCloud())
        {
            SetMoveSpeed(20f);
            CloudMove();
            
        }
        else
        {
            SetMoveSpeed(10f);
            PlayerMove();
        }
    }

    void CloudMove()
    {

        //키보드 w w 대쉬
        /*
        if (Input.GetKeyUp(KeyCode.W))
        {
            canRun = true;
            //transform.Translate(Vector3.forward * _moveSpeed * 2 * Time.deltaTime);
            
        }
        if(canRun == true)
        {
            checkRun -= Time.deltaTime;
            if(checkRun <= 0)
            {
                canRun = false;
                checkRun = 0.5f;
            }
        }
        if (Input.GetKey(KeyCode.W) && canRun == false)
            Dash(5.0f);
        else if (Input.GetKey(KeyCode.W) && canRun == true)
        {
            anim.SetBool("IsRunning", true);
            Dash(20.0f);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }
        */
        if(Input.GetKey(KeyCode.W))
        {
            anim.SetBool("IsRunning", true);
            Dash(5.0f);
        }
        else
            anim.SetBool("IsRunning", false);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * _moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime);
        }

       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigid.AddForce(Vector3.up * 15, ForceMode.Impulse);
            Ground_Check = false;
        }
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.E))
        {
            anim.SetBool("IsAttackRod", true);
            Debug.Log("길어져라");
        }
        else
            anim.SetBool("IsAttackRod", false);
    }

    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("IsRunning", true);
            Dash(5.0f);
        }
        else
            anim.SetBool("IsRunning", false);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * _moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime);
        }
    }

    void Jump()
    {
        transform.position += Vector3.up * 3;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Ground_Check = true;
        }
    }

    float GetMoveSpeed()
    {
        return _moveSpeed;
    }

    void SetMoveSpeed(float speed)
    {
        this._moveSpeed = speed;
    }
}
