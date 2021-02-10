using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    [SerializeField]
    float C_Attack_Damage;
    float Skill_E_Damage;

    Rigidbody player;
    Animator anim;
    bool cloud_check = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            
            anim.SetBool("isAttackRod_classic", true);
            Debug.Log("마우스 좌클릭");

        }
        else
            anim.SetBool("isAttackRod_classic", false);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("왼쪽 shift");
            GameObject tempobj = null;

            tempobj = GameObject.Find("Ch24_nonPBR").transform.FindChild("G_cloud").gameObject;

            if(tempobj != null && cloud_check == true)
            {
                
                Debug.Log("성공적으로 " + tempobj.name + "오브젝트를 받았습니다.");
                tempobj.SetActive(true);
                cloud_check = false;
                
            }
            else if(tempobj != null && cloud_check == false)
            {
                Debug.Log("근두운 해제");
                tempobj.SetActive(false);
                cloud_check = true;
            }
            else
            {
                Debug.LogError("실패");
            }
        }
            
    }

    public void setC_Damage(float damage)
    {
        this.C_Attack_Damage = damage; 
    }
}
