using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltGoing : MonoBehaviour
{

    float dis;
    float speed;
    float waitTime;

    public Transform TargetTr;
    public Transform Tr;
    
    // Start is called before the first frame update
    void Start()
    {
        dis = Vector3.Distance(Tr.position, TargetTr.position);

        transform.rotation = Quaternion.LookRotation(transform.position - Tr.position);
    }

    // Update is called once per frame
    void Update()
    {
        Operation();
        
    }

    void Operation()
    {
        if (TargetTr == null) return;

        waitTime += Time.deltaTime;

        if (waitTime < 1.5f)
        {
            speed = Time.deltaTime;
            transform.Translate(Tr.forward * speed, Space.World);
        }
        else
        {
            speed = Time.deltaTime;
            float t = speed / dis;

            Tr.position = Vector3.LerpUnclamped(Tr.position, TargetTr.position, t);
        }

        Vector3 directionVec = TargetTr.position - Tr.position;
        Quaternion qua = Quaternion.LookRotation(directionVec);
        Tr.rotation = Quaternion.Slerp(Tr.rotation, qua, Time.deltaTime * 5f);
    }
}
