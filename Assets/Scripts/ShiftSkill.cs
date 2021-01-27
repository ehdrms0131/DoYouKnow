using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftSkill : SkillManager
{
    void Skill()
    {
        if(tag=="player")
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (1<2)//플레이어의 무기가 card일 경우
                {
                    //통나무 생성
                    //한번 더 누르면 통나무와 위치 교체
                }
                else//무기가 만영봉일경우
                {
                    //player의 rigidbody의 중력을 0으로 만듦
                }
            }
        }
    }
}
