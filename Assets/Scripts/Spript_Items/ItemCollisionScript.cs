using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollisionScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Paddle"))
        {
            // 아이템과 패들이 충돌한 경우
            ApplyItemEffectToPaddle(other.GetComponent<Paddle>());

            // 아이템 사용 후 자신을 파괴
            Destroy(gameObject);
        }
    }

    private void ApplyItemEffectToPaddle(Paddle paddle)
    {
        // 아이템의 효과를 패들에 적용
        paddle.ApplyItemEffect(/* 필요한 매개변수에 따라 전달 */);
    }
}
