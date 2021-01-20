using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    void Start()
    {
        
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y,transform.position.z);
    }
}
