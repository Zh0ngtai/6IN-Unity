using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAddTime : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Paddle"))
        {

            GameManager.I.AddTime();
            Destroy(gameObject); // 아이템 파괴
        }
    }
}
