using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEnlargePaddle : MonoBehaviour
{
    public float enlargementAmount = 1.0f; // Paddle을 얼마나 늘릴지

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paddle"))
        {
            Paddle paddle = other.GetComponent<Paddle>();
            if (paddle != null)
            {
                paddle.SetPaddleWidth(paddle.originalWidth + enlargementAmount);
                Destroy(gameObject); // 아이템 소멸
            }
        }
    }
}
