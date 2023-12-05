using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShrinkPaddle : MonoBehaviour
{
    public float reductionAmount = 1.0f; // Paddle�� �󸶳� ������

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paddle"))
        {
            Paddle paddle = other.GetComponent<Paddle>();
            if (paddle != null)
            {
                float newWidth = Mathf.Max(paddle.originalWidth - reductionAmount, 0.1f); // �ּ� ũ�� ����
                paddle.SetPaddleWidth(newWidth);
                Destroy(gameObject); // ������ �Ҹ�
            }
        }
    }
}
