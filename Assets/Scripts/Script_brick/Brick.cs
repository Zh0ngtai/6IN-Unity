using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    int brickLife = 1;

    // 아이템 프리팹들을 인스펙터에서 설정할 수 있도록 설정
    public GameObject[] itemPrefabs;

    
    void FixedUpdate()
    {
        if (brickLife == 0)
        {
            // 30%의 확률로 아이템 생성
            if (Random.Range(0f, 1f) <= 0.3f)
            {
                SpawnRandomItem();
            }

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        brickLife--;
    }

    void SpawnRandomItem()
    {
        // 아이템 프리팹 배열에서 무작위로 하나를 선택
        int randomIndex = Random.Range(0, itemPrefabs.Length);
        GameObject randomItemPrefab = itemPrefabs[randomIndex];

        // 선택된 아이템을 현재 벽돌의 위치에 생성
        Instantiate(randomItemPrefab, transform.position, Quaternion.identity);
    }
}
