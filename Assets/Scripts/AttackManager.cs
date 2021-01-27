using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    //float change;

    bool b1;
    bool b2;
    public bool hasWeapons;  

    public enum Type { Card,Stick};
    public GameObject[] weapon;
    public bool hasWeapon;
    public Type type;
    public int damage;
    public float rate;

    void Swap()
    {
        int weaponIndex = -1;
        if (b1) weaponIndex = 0;
        if (b2) weaponIndex = 1;
        //change = Input.GetAxis("Fire 2");//정신집중
        b1 = Input.GetButtonDown("Mouse 0");
        b2 = Input.GetButtonDown("Mouse 1");
        if(b1 || b2)
        {
            //weapons[weaponIndex].SetActive(true);          
        }
    }
}
