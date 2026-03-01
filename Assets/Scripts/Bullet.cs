using UnityEngine;

public class Bullet : MonoBehaviour
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
        Vector3 dir = Vector3.up;

        // 2. 이동하고 싶다. 공식 P = P0 + v * t
        transform.position += dir * speed * Time.deltaTime;
    }
}

/*
3.1-3 : 총알 이동 제작
# 목표: 위로 계속 이동하고 싶다.
# 필요 속성: 이동 속도
# 순서
    1) 방향 구하기
    2) 이동하기
# 방향을 구해 이동하기.

3.1-4: 총알 발사 제작

*/