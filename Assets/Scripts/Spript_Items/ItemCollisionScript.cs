using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollisionScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Paddle"))
        {
            // �����۰� �е��� �浹�� ���
            ApplyItemEffectToPaddle(other.GetComponent<Paddle>());

            // ������ ��� �� �ڽ��� �ı�
            Destroy(gameObject);
        }
    }

    private void ApplyItemEffectToPaddle(Paddle paddle)
    {
        // �������� ȿ���� �е鿡 ����
        paddle.ApplyItemEffect(/* �ʿ��� �Ű������� ���� ���� */);
    }
}
