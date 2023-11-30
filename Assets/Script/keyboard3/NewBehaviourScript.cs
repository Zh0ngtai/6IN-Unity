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

    private Vector startPosition;

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



        transform.position = new Vector2(x, y);

    }

    public void Reset()
    {

        rigidbody.velocity = Vector2.zero;
        transform.position = startPosition;
    }
}
