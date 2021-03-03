using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterSight : MonoBehaviour
{

    public Transform target;
    [SerializeField] float m_angle = 0f;
    [SerializeField] float m_distance = 0f;
    [SerializeField] LayerMask m_layerMask = 0;

    Animator anim;
    NavMeshAgent nav;

    void Sight()
    {
        Collider[] t_cols = Physics.OverlapSphere(transform.position, m_distance, m_layerMask);//주변에 있는 플레이어 콜라이더를 검출


        if(t_cols.Length > 0)
        {
            Debug.Log("챕터1 작동중");
            Transform t_tfPlayer = t_cols[0].transform;

            Vector3 t_direction = (t_tfPlayer.position - transform.position).normalized;//플레이어 방향체크
            float t_angle = Vector3.Angle(t_direction, transform.forward);
            if(t_angle < m_angle * 0.5f)//ai의 방향과 플레이어 방향의 각도차이가 시야각 보다 작은지 확인
            {
                Debug.Log("몬스터 시야각 작동");
                if(Physics.Raycast(transform.position, t_direction, out RaycastHit t_hit, m_distance))//시야각 안에 있다면 레이를 플레이어에게 비춤
                {
                    Debug.Log("몬스터 레이케스트 작동");
                    //if(t_hit.transform.name == "Player")//바로 시야에 닿은게 플레이어라면 장애물이 없다고 간주
                    {
                        Debug.Log("몬스터 가는중");
                        //transform.position = Vector3.Lerp(transform.position, t_hit.transform.position, 0.02f);
                        nav.SetDestination(target.position);
                    }

                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Sight();
    }
}
