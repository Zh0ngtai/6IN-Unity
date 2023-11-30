using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle2 : MonoBehaviour
{
    public float paddleSpeed;  // �е� �̵� �ӵ� ����

    public KeyCode Right;
    public KeyCode Left;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // A Ű�� ������ -1, D Ű�� ������ 1�� �ǵ��� ����
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

        // �е��� x�����θ� �̵���Ŵ
        transform.Translate(new Vector3(horizontalInput * paddleSpeed * Time.deltaTime, 0, 0));
    }
}
