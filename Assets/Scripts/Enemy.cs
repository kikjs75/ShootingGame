using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 필요 속성: 이동 속도
    public float speed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 방향을 구한다.
        Vector3 dir = Vector3.down;

        // 2. 이동하고 싶다. 공식 P = P0 + v * t
        transform.position += dir * speed * Time.deltaTime;
    }

    // 충돌 시작
    void OnCollisionEnter(Collision collision)
    {
        // 너 죽고
        Destroy(collision.gameObject);

        // 나 죽자.
        Destroy(gameObject);
    }
}

/*
==========================================================================
# 목표 : 아래로 계속 이동하고 싶다
# 필요 속성 : 이동 속도
# 순서
    1) 방향 구하기
    2) 이동하기
# 총알의 이동 구현에서 방향만 다르군요.

==========================================================================
# 목표 : Enemy 가 어떤 물체와 충돌하면 둘 다 파괴하고 싶다.
# 필요 속성 : 이동 속도
# 순서
    1) 충돌을 위한 조건
    2) 물체끼리 충돌하기
    3) 충돌한 물체 파괴하기
# 유니티에서는 충돌하기 위해서 두 물체가 충돌체를 갖고 있어야 하며, 둘 중 하난에는 꼭 리지드바디가 있어야 합니다.    
# 컴포넌트	역할
Collider	"여기까지가 내 몸이다" (충돌 영역)
Rigidbody	물리 법칙 적용 (질량, 중력, 힘, 회전 등)
# Unity 물리엔진은
최소 한 쪽이 "물리 계산 대상"이면 충분
둘 다 Rigidbody가 있으면
→ 둘 다 밀리고 튕김
한 쪽만 있으면
→ Rigidbody 있는 쪽만 반응
→ 다른 쪽은 벽처럼 고정
# 충돌한 물체 인식
## 부딪히는 순간(충돌 시작) - 닿고 있는 중(충돌 중) - 떼는 순간(충돌 끝)

==========================================================================
# 3.1-6 : 적 자동 생성
# 목표 : 적을 일정 시간마다 내 위치에 생성하고 싶다.
# 순서
    1) Enemy 를 프리팹으로 만들기
    2) EnemyManager 게임 오브젝트 생성하기
    3) EnemyManager 스크립트 생성해 할당하기
    4) 적 생성 스크립트 구현하기
    5) 적 생성 시간을 랜덤하게 바꾸기

==========================================================================

*/