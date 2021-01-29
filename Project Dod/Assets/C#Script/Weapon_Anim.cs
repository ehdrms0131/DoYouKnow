using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Anim : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("T키 입력됨");
            animator.SetBool("isSkillon", true);
        }
        else
            animator.SetBool("isSkillon", false);
    }
}
