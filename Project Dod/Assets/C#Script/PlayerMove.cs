using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField]
    private float _moveSpeed = 0f;

    private Rigidbody _rigid = null;

    private bool Ground_Check = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
        }
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

        if (Ground_Check == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Come here");
                _rigid.AddForce(Vector3.up * 15 , ForceMode.Impulse);
                Ground_Check = false;
            }
        }
    }

    void Jump()
    {
        transform.position += Vector3.up * 3;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Ground_Check = true;
        }
    }
}
