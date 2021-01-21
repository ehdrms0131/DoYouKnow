using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    Camera playerCamera;

    private void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }
    void Start()    
    {
        Lock();
    }
    private void Lock()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitresult;
        if (Physics.Raycast(ray, out hitresult))
        {
            Vector3 mouseDir = new Vector3(hitresult.point.x, transform.position.y, hitresult.point.z) - transform.position;
            animator.transform.forward = mouseDir;
            return;
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }
}
