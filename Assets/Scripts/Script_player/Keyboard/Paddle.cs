using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool Palyer1;
    public float speed;
    public Rigidbody2D rigidbody;

    public KeyCode Right;
    public KeyCode Left;

    private float movement;
    private Vector3 startPosition;

    public AudioClip itemPickupSound;


    private float defaultPaddleWidth = 4.0f; // 패들의 기본 길이
    private float currentPaddleWidth;         // 현재 패들의 길이

    // 아이템 효과 적용 관련 변수
    private bool isItemActive = false;         // 아이템 효과 활성화 여부




    void Start()
    {
        startPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        currentPaddleWidth = defaultPaddleWidth;
    }


    void Update()
    {
        movement = 0f;
        if (Input.GetKey(Right)) { movement += 1f; }
        if (Input.GetKey(Left)) { movement -= 1f; }
        rigidbody.velocity = new Vector2( movement * speed,0);


    }

    public void Reset()
    {
        rigidbody.velocity = Vector3.zero;
        transform.position = startPosition;
        currentPaddleWidth = defaultPaddleWidth;
        isItemActive = false;
    }


    public void ApplyItemEffect(/* 어떤 매개변수가 필요한지에 따라 조절 */)
    {
        // 아이템에 따른 효과를 적용
        // 예: 크기 증가, 속도 증가, 무기 강화 등

        // 여기서는 패들의 길이를 늘리는 효과를 예시로 들었습니다.
        IncreasePaddleWidth(2.0f); // 예: 2.0f는 임의의 길이 증가량입니다.

        // 아이템 효과 활성화
        isItemActive = true;


        // 아이템을 먹을 때 소리를 재생
        PlaySound(itemPickupSound);
    }

    // 아이템 효과 해제
    private void ResetPaddleWidth()
    {
        currentPaddleWidth = defaultPaddleWidth;
        isItemActive = false;
    }


    // 패들의 길이를 증가시키는 함수
    private void IncreasePaddleWidth(float increaseAmount)
    {
        // x 축으로만 길이를 늘립니다.
        transform.localScale = new Vector3(currentPaddleWidth + increaseAmount, transform.localScale.y, transform.localScale.z);
    }

    // 아이템 효과가 발동될 때 랜덤한 사운드 재생


    // 사운드 재생 함수
    private void PlaySound(AudioClip sound)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }

}
