using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 현재 시간
    float currentTime;

    // 일정 시간
    public float createTime = 1;

    // 적 공장
    public GameObject enemyFactory;

    // 최소 시간
    float minTime = 1;

    //  최대 시간
    float maxTime = 5;

    // 방향을 전역 변수로 만들어 Start와 Update에서 사용
    Vector3 dir;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 태어날 때 적의 생성 시간을 설정하고
        createTime = UnityEngine.Random.Range(minTime, maxTime);

        // 0부터 9까지 10개의 값 중에 하나를 랜덤으로 가져온다.
        int randValue = UnityEngine.Random.Range(0, 10);

        if(randValue < 3)
        { // 만약 3보다 작으면 플레이어 방향
            // 플레이어를 찾아 target으로 하고 싶다.
            GameObject target = GameObject.Find("Player");
            // 방향을 구하고 싶다. target-me
            dir = target.transform.position - transform.position;
            // 방향의 크기를 1로 하고 싶다.
            dir.Normalize();
        }
        else
        { // 그렇지 않으면 아래 방향으로 정하고 싶다.
            dir = Vector3.down;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // 1) 시간이 흐르다가
        currentTime += Time.deltaTime;

        // 2) 만약 현재 시간이 일정 시간이 되면
        if(currentTime > createTime)
        {
            // 3) 적 공장에서 적을 생성해
            GameObject enemy = Instantiate(enemyFactory);

            //  내 위치에 갖다 놓고 싶다.
            enemy.transform.position = transform.position;

            // 결정한 방향을 적에게 전달한다.
            enemy.GetComponent<Enemy>().dir = dir;

            // 현재 시간을 0으로 초기화.
            //  => 현재 시간이 일정 시간이 되고 난 후 계속 일정 시간보다 크기 때문에 적을 마구 생성합니다.
            //      그리고 Enemy 가 서로 부딪혀 계속 파괴도고 있습니다.
            //      이를 해결하기 위해서 현재 시간을 0으로 초기화해야 합니다.
            currentTime = 0;

            // 적을 생성한 후 적의 생성 시간을 다시 설정하고 싶다.
            createTime = UnityEngine.Random.Range(minTime, maxTime);
        }


    }
}

/*
==========================================================================
# 목표 : 일정 시간마다 적을 생성해 내 위치에 갖다 놓고 싶다.
# 필요 속성 : 일정 시간, 현재 시간, 적 공장
# 순서
    1) 시간이 흐르다가
    2) 만약 현재 시간이 일정 시간이 되면
    3) 적 공장에서 적을 생성해 내 위치에 갖다 놓고 싶다.

==========================================================================
# 목표 : 적이 생성될 때마다 다음 생성 시간을 랜덤하게 바꾸ㄱ.
# 필요 속성 : 최소 시간, 최대 시간

==========================================================================
# 3.1-7 : 적의 인공지능(플레이어 방향 찾기)
# 목표 : 30% 확률로 플레이어 방향, 나머지 확률로 아래 방향으로 정하고 싶다. 단, 태어날 때 방향을 정하고 그 방향으로 계속 이동하고 싶다.
# 필요 속성 : 없음
# 순서
    1) 30% 확률로 플레이어 방향, 나머지 확률로 아래 방향
    2) 태어날 때 방향을 정하고 그 방향으로 계속 이동하기

*/
