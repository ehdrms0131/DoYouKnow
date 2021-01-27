using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : AttackManager
{
    public BoxCollider area;
    public void Use()//메인루틴
    {
        if (type == Type.Card)//무기 타입이 카드일경우
        {
            StopCoroutine("Throw");//코루틴 정지
            StartCoroutine("Throw");//코루틴 시작
        }
    }
    IEnumerator Throw()//서브루틴
    {
        // yield return null;//1프레임 대기 여러개 작성 가능
        yield return new WaitForSeconds(0.3f);//1f동안 대기
        area.enabled = true;
        yield return new WaitForSeconds(0.3f);
        area.enabled = false;
        yield break; //위에있으면 아래 비활성화
    }
}
