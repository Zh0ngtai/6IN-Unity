using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle2 : MonoBehaviour
{
    public float paddleSpeed;  // 패들 이동 속도 변수

    public KeyCode Right;
    public KeyCode Left;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // A 키를 누르면 -1, D 키를 누르면 1이 되도록 설정
        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f;
        }
        else
        {
            horizontalInput = 0f;
        }

        // 패들을 x축으로만 이동시킴
        transform.Translate(new Vector3(horizontalInput * paddleSpeed * Time.deltaTime, 0, 0));
    }
}
