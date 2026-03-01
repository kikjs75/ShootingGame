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
# <영역 감지 스크립트 구현하기>
# 목표 : 영역 안에 다른 물체가 감지될 경우 그 물체를 없애고 싶다.
## Destory 함수 : 씬에 있는 GaemObject 을 완전히 없애고, 자원 반납까지 해주는 역할. Collider 타입 other 객체가 아니라 other.gameObject 을 넣어주는 이유.
## DestoryZone 객체가 갑자기 사라져버리는 것 확인. 이유는 객체가 지금 양끝 부분이 겹쳐지도록 배치돼 있어 서로 부딪히면 상대를 없아버리기 때문. DestoryZone 들끼리 서로 충돌되지 않도록 설정해서 문제 해결.

# <컴포넌트 색깔 변경>
1) Material 을 새롭게 만들어야한다. 
- Asseets 에 Material 디렉토리 만들고 Material 을 새롭게 추가한다. 목적에 맞게 이름 지정(BulletMat, PlayerMat)
2) 신규 Material 설정
- Material 의 Shader 을 Unlit/Color 로 변경 후 Main Color 을 원하는 색을 설정. 
=> Lit(light의 과거형/과거분사, 빛을 받은)
=> Lit Shader(조명에 영향을 받지 않는 머티리얼), Unlit Shader(조명에 영향을 받지 않는 머티리얼)
3) 신규 Material 해당 컴포넌트에 설정
- 해당 컴포넌트에서 Mesh Renderer -> Materials -> Elements 0 을 신규 Material 설정. 기존에 Lit 로 되어져 있음. 
*/