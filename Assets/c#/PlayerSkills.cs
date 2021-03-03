using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{

    private static PlayerSkills instance = null;

    [SerializeField]
    float C_Attack_Damage = 0f;
    float Skill_E_Damage;
    float Skill_Magic_Damage = 30f;


    float delayTime = 2.0f;

    bool CanAttack;

    Rigidbody player;
    Animator anim;

    bool cloud_check = true;
    static bool _magicA_check = true;

    private void Awake()
    {
        player = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        if (null == instance)
        {
            //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //싱글톤 사용
    public static PlayerSkills Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        Player_Cloud();
        if (isCloud() == false)
        {
            Player_C_Attack();
            Magic_skill();
        }
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(1);
    }

    void Player_C_Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            setC_Damage(20f);
            anim.SetBool("isAttackRod_classic", true);
            Debug.Log("마우스 좌클릭");

            StartCoroutine(CountAttackDelay());
            Debug.Log("A케2복");
        }
        else
            anim.SetBool("isAttackRod_classic", false);
    }

    [System.Obsolete]
    void Player_Cloud()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("왼쪽 shift");
            GameObject tempobj = null;

            tempobj = GameObject.Find("Ch24_nonPBR").transform.FindChild("G_cloud").gameObject;

            if (tempobj != null && cloud_check == false)
            {

                Debug.Log("성공적으로 " + tempobj.name + "오브젝트를 받았습니다.");
                tempobj.SetActive(true);
                cloud_check = true;

            }
            else if (tempobj != null && cloud_check == true)
            {
                Debug.Log("근두운 해제");
                tempobj.SetActive(false);
                cloud_check = false;
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

    public float Get_C_Damage()
    {
        return C_Attack_Damage;
    }

    public float Get_Skill_A_Damage()
    {
        return Skill_Magic_Damage;
    }

    public bool isCloud()
    {
        return cloud_check;
    }

    [System.Obsolete]
    private void Magic_skill()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q입력");
            GameObject magic_obj = null;

            magic_obj = GameObject.Find("Ch24_nonPBR").transform.FindChild("Magic_ball").gameObject;

            if (magic_obj != null && MagicA_check)
            {

                Debug.Log("성공적으로 " + magic_obj.name + "오브젝트를 받았습니다.");
                magic_obj.SetActive(true);
                Instantiate(magic_obj);
            }
            else
            {
                Debug.LogError("마법 A 실패");
            }
        }
    }

    public bool MagicA_check{
        get
        {
            return _magicA_check;
        }
        set 
        {
            _magicA_check = value;
        }
    }

    IEnumerator CountAttackDelay()
    {
        yield return new WaitForSeconds(delayTime);
    }
}
