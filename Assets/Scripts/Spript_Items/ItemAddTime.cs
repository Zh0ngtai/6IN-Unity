using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAddTime : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Paddle"))
        {
            // 아이템과 패들이 충돌한 경우
            GameManager.I.AddTime();
            Destroy(gameObject); // 아이템 파괴
        }
    }
}
