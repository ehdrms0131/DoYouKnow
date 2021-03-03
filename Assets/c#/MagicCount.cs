using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCount : MonoBehaviour
{
    [SerializeField]
    GameObject magic; 

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    void Shoot()
    {
        transform.position += Vector3.forward * 3;
        Die();
    }

    private void Die()
    {

        Destroy(magic, 2);
        PlayerSkills.Instance.MagicA_check = true;
    }
}
