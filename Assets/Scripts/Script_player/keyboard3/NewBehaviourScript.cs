using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public bool Player1;
    public float speed;
    public Rigidbody2D rigidbody;
    public KeyCode Right;
    public KeyCode Left;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 키보드 입력에 따른 이동
        float horizontalInput = 0f;

        if (Input.GetKey(Right)) { horizontalInput += 1f; }
        if (Input.GetKey(Left)) { horizontalInput -= 1f; }

        rigidbody.velocity = new Vector2(horizontalInput * speed, 0);

        // 키보드 입력에 따른 x 위치 제한
        float x = transform.position.x;

        if (x > 17.5f)
        {
            x = 17.5f;
        }
        if (x < -17.5f)
        {
            x = -17.5f;
        }

        // 키보드 입력에 따른 y 위치 제한
        float y = transform.position.y;

        if (y > 9f)
        {
            y = 9f;
            x = 0f;
        }

        // 패들 위치 설정
        transform.position = new Vector3(x, y, 0);
    }

    public void Reset()
    {
        rigidbody.velocity = Vector3.zero;
        transform.position = startPosition;
    }
}
