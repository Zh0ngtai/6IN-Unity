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

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
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
    }


    public void ApplyItemEffect(/* 어떤 매개변수가 필요한지에 따라 조절 */)
    {
        // 아이템 효과를 패들에 적용
        // 예: 크기 증가, 속도 증가, 무기 강화 등
        IncreasePaddleSize(1f);
    }

    private void IncreasePaddleSize(float increaseAmount)
    {
        // 현재 크기와 증가량을 고려하여 패들의 크기를 증가시킴
        Vector3 currentScale = transform.localScale;
        float newSize = currentScale.x + increaseAmount;
        transform.localScale = new Vector3(newSize, currentScale.y, currentScale.z);
    }
}
