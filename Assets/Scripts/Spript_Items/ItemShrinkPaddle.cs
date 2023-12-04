using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShrinkPaddle : MonoBehaviour
{
    public float reductionAmount = 1.0f; // Paddle을 얼마나 줄일지

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paddle"))
        {
            Paddle paddle = other.GetComponent<Paddle>();
            if (paddle != null)
            {
                float newWidth = Mathf.Max(paddle.originalWidth - reductionAmount, 0.1f); // 최소 크기 제한
                paddle.SetPaddleWidth(newWidth);
                Destroy(gameObject); // 아이템 소멸
            }
        }
    }
}
