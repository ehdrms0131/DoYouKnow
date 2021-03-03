using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCount : MonoBehaviour
{
    GameObject magic;
    // Start is called before the first frame update
    void Start()
    {
        magic = GetComponent<GameObject>();
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
        Destroy(magic, 0.2f);
    }
}
