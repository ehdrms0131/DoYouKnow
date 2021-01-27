using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QSkill : SkillManager
{
    void Skill()
    {
        if (tag == "player")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (1 < 2
                    //weapon.tag="card"
                    )//플레이어의 무기가 card일 경우
                {
                    //n초동안 차징->크기/뎀 증가
                    //한번 더 누르면 통나무와 위치 교체
                }
                else//무기가 만영봉일경우
                {
                    //행성 떨구기(istrigger인 구를 s의 속도로 n초동안 player.transform에서 z로부터 20떨어진곳에 떨어트리고,d초 후에 소멸시킨다
                    //tag가 enemy인 적은 닿으면 1초 뒤에 소멸한다
                }
            }
        }
    }
}
