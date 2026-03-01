using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 총알을 생산하는 공자
    public GameObject bulletFactory;

    // 총구
    public GameObject firePosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 목표: 사용자가 발사 버튼을 누르면 총알을 발사하고 싶다.
        // 순서: 1. 사용자가 발사 버튼을 누르면
        //      만약, 사용자가 발사 버튼을 누르면
        if (Input.GetButtonDown("Fire1"))
        {
            // 2. 총알 공장에서 총알을 만든다.
            GameObject bullet = Instantiate(bulletFactory);
            // 3. 총알을 발사한다.
            bullet.transform.position = firePosition.transform.position;
        }
        
    }
}

/*
==========================================================================
# 목표: 사용자가 발사 버튼을 누르면 총알을 발사하고 싶다.
# 필요 속성: 총알을 생산할 공장, 총구.
## Fire Positon
    총구는 플레이어가 이동할 때 함게 붙어 다녀야 하기 때문에 플레이어 객체의 자식으로 등록합니다.
    FirePosition 객체를 Player 의 PlayFire 스크립트에 할당.


==========================================================================
# 목표: 사용자가 발사 버튼을 누르면 총알을 발사하고 싶다.
# 순서
    1) 사용자가 발사 버튼을 누르면
    2) 총알 공장에서 총알을 만든다.
    3) 총알을 발사한다.

==========================================================================
# 목표: 적을 만들어 이동 처리하고 싶다. 그리고 충돌 처리도 하고 싶다.
# 순서
    1) 적 게임오브젝트 생성하기
    2) 이동 스크립트를 생성해 할당하기
    3) 이동 스크립트 구현하기
    4) 다른 물체와 충동시키기
*/
