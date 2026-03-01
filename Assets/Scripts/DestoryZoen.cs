using UnityEngine;

public class DestoryZoen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 영역 안에 다른 물체가 감지될 경우
    void OnTriggerEnter(Collider other)
    {
        // 그 물체를 없애고 싶다.
        Destroy(other.gameObject);
    }
}

/*
# <3.1-8 : DestoryZoen과 총돌 감지>
# 목표 : 화면을 벗어나는 물체를 제거해 메모리의 낭비를 막고 싶다.
# 순서
    1) 영역 감지 게임 오브젝트 생성하기
    2) 영역 감지 스크립트 생성해 할당하기
    3) 영역 감지 스크립트 구현하기

==========================================================================
# >영역 감지 스크립트 구현하기>
# 목표 : 영역 안에 다른 물체가 감지될 경우 그 물체를 없애고 싶다.
## Destory 함수 : 씬에 있는 GaemObject 을 완전히 없애고, 자원 반납까지 해주는 역할. Collider 타입 other 객체가 아니라 other.gameObject 을 넣어주는 이유.
## DestoryZone 객체가 갑자기 사라져버리는 것 확인. 이유는 객체가 지금 양끝 부분이 겹쳐지도록 배치돼 있어 서로 부딪히면 상대를 없아버리기 때문. DestoryZone 들끼리 서로 충돌되지 않도록 설정해서 문제 해결.
*/