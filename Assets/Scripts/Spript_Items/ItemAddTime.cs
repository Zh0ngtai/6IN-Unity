using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAddTime : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Paddle"))
        {
            // �����۰� �е��� �浹�� ���
            GameManager.I.AddTime();
            Destroy(gameObject); // ������ �ı�
        }
    }
}
