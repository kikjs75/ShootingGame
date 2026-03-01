using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 플레이어가 이동할 속력
    public float speed = 5;

    // 초기 위치
    Vector3 initPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initPos = transform.position;
    }

    public void Respawn()
    {
        transform.position = initPos;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // X axis
        float v = Input.GetAxis("Vertical"); // Y axis
        print("h : " + h + ", v :" + v);

        // Vector3 dir = Vector3.right * h + Vector3.up * v; // 방법1) 벡터 더하기 적용. 오브젝트 기준(FPS, 자동차 게임)
        Vector3 dir = new Vector3(h, v, 0); // 방법2) 벡터 더하기 적용. 월드 기준(2D)

        // transform.Translate(dir * speed * Time.deltaTime); // 방법1) 플레이어 이동시키기
        transform.position += dir * speed * Time.deltaTime; // 방법2) 플레이어 이동시키기. P = P0(현재위치) + v * t
        // P = P0 + v0(dir + a) * t => 현재속도 v0는 dir(방향) + a(가속도) 이고 여기에 t(시간) 곱하면 미래위치(P) 된다.
    }
}

/*
(x, y, z)
right.  : (1,0,0) => x(left:양수, right:음수, not press:0) => left(-1,0,0)
up      : (0,1,0) => y(top:양수, down:음수, not press:0) => down(0,-1, 0)
forward : (0,0,1) => z(forward:양수, back:음수, not press:0) => back(0,0,-1)
반대방향  : -1 곱한다.
크기(속도) 모두 1인 벡터. 방향만 갖고 있는 형태.
*/

/*
Unity 은 왼손 좌표계르 사용. 그래서 X 축(양수:오른쪽, 음수:왼쪽), Y축(양수:위, 음수:아래), Z축(양수:앞, 음수:뒤)

만약, 오른쪽 90도 회전하면 왼손 좌표계를 오른쪽 90도로 돌리면 된다. 
    처음에는 X(right),Y(top),Z(forward) => X(back),Y(top),Z(right) 된다. 
    오른쪽 90도 회전이므로 Y축 기준으로 돌렸으므로 기준축은 변하지 않는다.

월드 기준 vs 오브젝트 기준
    Vector3 dir = Vector3.right * h + Vector3.up * v;       // 방법1) 월드 기준(2D)
    Vector3 dir = new Vector3(h, v, 0);                     // 방법2) 월드 기준(2D)
    Vector3 dir = transform.right * h + transform.up * v;   // 방법3) 오브젝트 기준(FPS, 자동차 게임)

    월드 기준 : 회전해도 방향이 안 바뀐다.
    오브젝트 기준 : 회전해도 방향이 바뀐다.

*/

/*
Transform.Translate() 함수에 종속적. 그래서 이를 구현한다. 이런 경우가 많다.

1) P = P0 + v * t
P:미래 위치, P0:현재 위치, v:속도, t:시간
등속운동 공식. 앞으로의 위치(P)에 영향을 미치는 것이 속도(v) 입니다.
그럼, 속도(v) 에 양향을 미치는 것은 무엇일까요?

2) v = v0 + a * t => 속도
v:속도, v0:현재속도, a:가속도, t:시간
등가속도 운동 공식. 그럼, 가속도는 어떻게?

3) F = m * a => 가속도
F(Force):힘, m(Mass):질량, a(Acceleration):가속도
질량이 1이면 F는 곧 가속도(a)가 된다.

그래서 전체를 연결하면 
    누군가 밀면 힘(F)이 발생하고, 이는 곧 가속도 a 가 생기는 것이다. 
    가속도 a 는 현재 속도 v0에 영향을 미쳐 속도 v에 변화을 일으키고,
    최종 P0와 더해져 미래 위치 P가 결정된다.
    즉, 물체에 힘이 가해져 속도가 생긱고 위치에 변경을 가하는 과정이다.

Mass(질량)과 Weight(무게)는 다르다. Mass 는 어디서든 동일하다. 그러나 Weight 은 위치에 따라 동일하지 않을 수 있다. 변수는 중력이다. 중력이 낮으면 Weight(무게) 다를 수 있다.    
Mass(질량) : 무게가 얼마나 "무거운 성질"을 가지고 있는지?
Weight(무게) : 중력이 끌어 당기는 힘이 얼마인지?

Acceleration(가속도) : 속도가 얼마나 빨리 변하는지?

속도(v) vs 가속도(a)
    속도(v) : 얼마나 빠르게 + 어느 방향 => 10 m/s^2 or 오른쪽 5 m/s^2
    가속도(a) : 속도가 얼마나 빨리 변하는가 => 10 m/s^2
    위치(P) : 속도(얼마나 빠르게 + 어느 방향) + 시간

*/
