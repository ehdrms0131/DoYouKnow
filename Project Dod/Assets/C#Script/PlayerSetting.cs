using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{

    public int Rod_attack_damage = 120;



    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    //최대 체력
    public float player_healthMax;

    //현재 체력
    public float player_healthLive;

    //체력바
    public SliderJoint2D healthSlider;

    //사망시 오디오 클립
    public AudioClip deathClip;

    //체젠
    float health_re;

    //피격 체크
    bool isAttack;

    //비전투 체크
    bool isFight;

    //죽음 체크
    private bool isDead;
    //데미지 체크
    private bool damaged;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public int Rod_Attack()
    { 
        return Rod_attack_damage;
    }

    public void Set_damage(int damage)
    {
        this.Rod_attack_damage = damage;
    }

    public void TakeDamage(int amount)
    {

    }



}
