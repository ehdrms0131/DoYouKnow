using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    private Animator anim;
    private GameObject player;
    private PlayerSetting P_health;
    private EnemySetting E_health;

    private bool playerInRange;
    private float timer;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        P_health = player.GetComponent<PlayerSetting>();
        E_health = GetComponent<EnemySetting>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange && E_health.E_healthLive > 0)
        {
            Attack();
        }

        
        //if(P_health.player_healthLive <= 0)
        //{
        //  anim.SetTrigger("PlayerDead");
        //}
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            playerInRange = false;
        }
    }


    void Attack()
    {
        timer = 0f;

        if(P_health.player_healthLive > 0)
        {
            P_health.TakeDamage(attackDamage);
        }
    }
}
