# 6IN-Unity https://github.com/Zh0ngtai/6IN-Unity/issues

# 집에 가고 싶은 르탄이

##스타트씬

> - 스테이지 총 3개 선택 가능
> - 르탄이 시작 애니메이션 추가

##메인씬
> - 플레이 화면과 UI화면을 구분하여 생성
> - 스테이지1을 기반으로 씬 이름에 따라 벽돌 생성 패턴이 바뀌게 하여 난이도 조절
> - Ball의 Y좌표값이 -10이하일 때 게임이 종료되도록 설정
#Brick
![image](https://github.com/Zh0ngtai/6IN-Unity/assets/149444430/47e02a08-3a99-4958-92c9-db52d0d60962)
> - 공과 충돌 시 아이템 생성
> - BrickLife 매개변수를 사용하여 Ball과 충돌 횟수 카운트
#Paddle
![image](https://github.com/Zh0ngtai/6IN-Unity/assets/149444430/4c843ba9-0209-4a0f-9788-040306a18a03)
> - 아이템과 충돌하면 각 아이템의 기능을 구현함
> - 키보드 입력값을 받아 좌우로 움직임

#Ball
![image](https://github.com/Zh0ngtai/6IN-Unity/assets/149444430/48fc66cd-2c27-422d-949b-345c98ac507a)
![Ball](https://github.com/Zh0ngtai/6IN-Unity/assets/149444430/a0968c87-ae6a-434a-9c0d-c3c9513134d6)
> - 공 움직임 : rigidbody 부여하고 무중력 상태로 만들었습니다, physics 2D 적용해서 friction (마찰력) 은 0으로, bouciness (튕기는 정도) 는 1로 설정
             벽돌, 패드와 충돌 시 자연스럽게 튕기고 일정한 속도로 움직임
> - 공 시작 : 공이 생성됐을 때 x 축으로 -0.5 ~ 0.5 사이의 랜덤 값의 힘이 주어지고 y 축으로는 0.5의 고정된 값의 힘이 주어져서 적당한 속도와 방향으로 나아감
> - 공-벽 상호작용 : 벽과 부딪힐 때는 각도에 따라 그에 맞는 각도로 튕길 수 있게 script 를 구성하고 Euler Angle을 활용
#Item
![Ade](https://github.com/Zh0ngtai/6IN-Unity/assets/149444430/fda26411-f43e-4f70-90a1-8db9536858be)
> - 패들과 충돌 시 타임 게이지가 증가함
![Chocolate](https://github.com/Zh0ngtai/6IN-Unity/assets/149444430/d62a61eb-5429-47cc-97d0-0ab4d6b66506)
> - 패들의 크기를 늘여줌
![Rock](https://github.com/Zh0ngtai/6IN-Unity/assets/149444430/d7cdf5d7-78f8-43fb-9d77-929716b4c7e9)
> - 패들의 크기를 줄임(디버프 아이템)
![image](https://github.com/Zh0ngtai/6IN-Unity/assets/149444430/c8db3623-1eb3-4dbc-be99-58773f651689)
> - 공의 개수를 늘임
<br>
#게임 종료
> - 여러 개 생성될수 있는 공이 모두 y좌표값 -10 이하로 떨어져 파괴되었을 경우
> - 시간 게이지가 0이 되어 플레이타임이 남아있지 않는 경우
> - 벽돌이 모두 파괴되어 스테이지를 클리어한 경우

#UI
> - 타임 게이지 구현
> - 아이템 획득에 따라 타임 게이지 상승
> - 게임 종료 시 기록 및 최고 기록 저장

#기획의도
> - 게임의 스토리 : 길을 가다 싱크홀에 빠져 벽돌을 클리어하고 지상으로 돌아가기
> - 게임의 컨셉에 맞는 아이템들 출현
> - 생존에는 물이 가장 중요하기 때문에 음료 아이템을 먹게 되면 시간 연장 > 게임 플레이의 가장 중요한 아이템
> - 단계별로 배경이 점점 지상과 가까워짐
> - 동굴이라는 컨셉에 맞는 장애물(박쥐) 등장
