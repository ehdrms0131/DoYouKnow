    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

public class AttackManager : MonoBehaviour//PlayerController
{
    //float change;

    bool b1;
    bool b2;
    bool b3;

    public GameObject[] weapons;
    public GameObject equip;
    public bool[] hasWeapons;

    public enum Type { Card, Stick };
    public Type type;
    public int damage;
    public float rate;

    private void Update()
    {
        Swap();
    }
    void Swap()
    {
        int weaponIndex = 0;
        if (b2)
        {
            weaponIndex = 1;
        }
        if (b3)
        {
            weaponIndex = 2;
        }
        if(hasWeapons[0])
        {
             
        }


        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("b2 입력됨");
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("b3 입력됨");
        }
        b2 = Input.GetButtonDown("Fire1");
        b3 = Input.GetButtonDown("Fire2");
        if (b1 || b2 || b3)
        {
            if (equip != null)
            {
                equip.SetActive(false);
            }
            equip = weapons[weaponIndex];
            equip.SetActive(true);
        }
    }
}
