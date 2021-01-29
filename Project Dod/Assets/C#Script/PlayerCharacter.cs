using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    private bool _isGround = true;
    [SerializeField]
    private bool _isJump = false;

    public bool isGround
    {
        get { return _isGround; }
        set { _isGround = value; }
    }

    public bool isJump
    {
        get { return _isJump; }
        set { _isJump = value; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground");
            _isGround = true;
            _isJump = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground");
            _isGround = false;
            _isJump = true;
        }
    }
}
