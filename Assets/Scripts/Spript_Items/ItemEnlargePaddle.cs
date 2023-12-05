using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEnlargePaddle : MonoBehaviour
{
    public float enlargementAmount = 1.0f; // Paddle�� �󸶳� �ø���

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paddle"))
        {
            Paddle paddle = other.GetComponent<Paddle>();
            if (paddle != null)
            {
                paddle.SetPaddleWidth(paddle.originalWidth + enlargementAmount);
                Destroy(gameObject); // ������ �Ҹ�
            }
        }
    }
}
