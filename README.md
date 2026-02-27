# ShootingGame

Unity 3D 슈팅 게임 프로젝트입니다.

---

## 프로젝트 구조

```
Assets/
├── Scenes/
│   └── SampleScene.unity
├── Scripts/
│   └── PlayerMove.cs       # 플레이어 이동 스크립트
└── Settings/               # URP 렌더 파이프라인 설정
```

---

## Scripts

### PlayerMove.cs

매 프레임마다 키보드 입력을 받아 플레이어를 이동시키는 스크립트입니다.

#### 핵심 동작

```csharp
float h = Input.GetAxis("Horizontal"); // A/D 또는 좌우 방향키 → -1 ~ 1
float v = Input.GetAxis("Vertical");   // W/S 또는 상하 방향키 → -1 ~ 1

Vector3 dir = new Vector3(h, v, 0);   // 이동 방향 벡터 (2D 평면)

transform.position += dir * speed * Time.deltaTime; // 위치 업데이트
```

#### 이동 공식

```
P = P0 + v * t
```

| 변수 | 의미 |
|------|------|
| `P` | 미래 위치 |
| `P0` | 현재 위치 (`transform.position`) |
| `v` | 방향 × 속도 (`dir * speed`) |
| `t` | 프레임 간격 (`Time.deltaTime`) |

`Time.deltaTime`을 곱해 프레임레이트에 관계없이 일정한 속도를 보장합니다.

#### 이동 방법 비교

| 방법 | 코드 | 특징 |
|------|------|------|
| 방법1 | `transform.Translate(dir * speed * Time.deltaTime)` | Unity 내장 함수 사용 |
| 방법2 | `transform.position += dir * speed * Time.deltaTime` | 물리 공식 직접 구현 (현재 사용) |

#### 방향 기준 비교

| 기준 | 코드 예시 | 특징 |
|------|-----------|------|
| 월드 기준 | `Vector3.right * h + Vector3.up * v` | 오브젝트가 회전해도 방향 고정 |
| 월드 기준 (단축) | `new Vector3(h, v, 0)` | 위와 동일 (현재 사용) |
| 오브젝트 기준 | `transform.right * h + transform.up * v` | 오브젝트 회전 시 방향도 변경 (FPS, 자동차 게임에 적합) |

#### Unity 좌표계

Unity는 **왼손 좌표계**를 사용합니다.

```
X축 : 양수 → 오른쪽,  음수 → 왼쪽
Y축 : 양수 → 위,      음수 → 아래
Z축 : 양수 → 앞,      음수 → 뒤
```

#### 물리 공식 흐름

현재 구현은 등속운동이지만, 물리 기반 확장 시 아래 공식을 따릅니다.

```
F = m * a     (힘 → 가속도)
v = v0 + a*t  (가속도 → 속도)
P = P0 + v*t  (속도 → 위치)
```

| 개념 | 설명 |
|------|------|
| `F` (Force) | 힘. 외부에서 가해지는 힘 |
| `m` (Mass) | 질량. 어디서든 동일한 값 |
| `a` (Acceleration) | 가속도. 속도가 변하는 비율 |
| `v0` | 현재 속도 |
| `v` | 변화 후 속도 |

> **Mass vs Weight**: Mass(질량)는 어디서든 동일하지만, Weight(무게)는 중력에 따라 달라집니다.

#### 현재 구현 상태

현재는 가속도 없이 키 입력 즉시 `speed = 5` 속도로 이동하는 **등속운동** 방식입니다.
추후 `v = v0 + a * t` 공식을 적용하면 관성 및 가속/감속 효과를 추가할 수 있습니다.
