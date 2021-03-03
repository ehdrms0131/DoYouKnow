using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySetting : MonoBehaviour
{
    public PlayerSkills player_Attack_C;



    public int E_attack;

    public float sinkSpeed = 2.5f;

    public int scoreValue = 10;

    //최대 체력
    public float E_healthMax = 500f;

    //현재 체력
    public float E_healthLive;

    public AudioClip deathClip;

    private Animator anim;
    private AudioSource enemyAudio;
    private ParticleSystem hitParticles;
    private CapsuleCollider capsuleCollider;
    private bool isDead;
    private bool isSinking;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        E_healthLive = E_healthMax;
    }

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
        if (E_healthLive < 0)
            Debug.Log("봉한테 맞아죽음");
    }

    //private void OnCollisionEnter(Collision other)
    //{
        
    //}

private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rod"))
        {
            Debug.Log("봉만영");
            

            E_healthLive -= PlayerSkills.Instance.Get_C_Damage();
        }
        if(other.gameObject.CompareTag("MagicA"))
        {
            Debug.Log("마법으로 맞아쪄..");
            E_healthLive -= PlayerSkills.Instance.Get_Skill_A_Damage()
        }
    }
}
