using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosspattern : MonoBehaviour
{

    [SerializeField] float m_angle = 0f;
    [SerializeField] float m_distance = 0f;
    [SerializeField] LayerMask m_layerMask = 0;

    public Object bolt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BossPatern()
    {
        Collider[] t_cols = Physics.OverlapSphere(transform.position, m_distance, m_layerMask);

        if(t_cols.Length > 0)
        {
            Debug.Log("플레이어 검출중");
            Transform t_tfPlayer = t_cols[0].transform;

            Vector3 t_direction = (t_tfPlayer.position - transform.position).normalized;
            float t_angle = Vector3.Angle(t_direction, transform.forward);
            if(t_angle < m_angle * 0.5f)
            {
                if(Physics.Raycast(transform.position, t_direction, out RaycastHit t_hit, m_distance))
                {
                    Debug.Log("볼트 레이케스트");
                    transform.position = Vector3.Lerp(transform.position, t_hit.transform.position, 2f);
                }
            }


        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Rod"))
        {
            Instantiate(bolt);
            Debug.Log("보스 피격");
        }
    }

    //IEnumerator StateCastCrossAttack()
    //{
    //    float randomY = Random.Range(0, 360f);

    //}
}
