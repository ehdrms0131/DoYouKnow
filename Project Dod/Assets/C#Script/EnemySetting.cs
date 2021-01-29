using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySetting : MonoBehaviour
{

    public int E_attack;

    public float sinkSpeed = 2.5f;
    
    public int scoreValue = 10;

    //최대 체력
    public int E_healthMax;

    //현재 체력
    public int E_healthLive;

    public AudioClip deathClip;
    
    PlayerSetting player;
    

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

    // Update is called once per frame
    void Update()
    {
        
        if(isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
        if(E_healthLive <= 100)
        {
            Debug.Log("사망");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Rod"))
        {
            Debug.Log("흐읏");
        }
    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (isDead)
            return;

        enemyAudio.Play();

        E_healthLive -= amount;

        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(E_healthLive <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play();
    }    

    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;

        Destroy(gameObject, 2f);
    }
}
