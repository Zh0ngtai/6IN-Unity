using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    int brickLife = 1;

    // ������ �����յ��� �ν����Ϳ��� ������ �� �ֵ��� ����
    public GameObject[] itemPrefabs;

    
    void FixedUpdate()
    {
        if (brickLife == 0)
        {
            // 30%�� Ȯ���� ������ ����
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
        // ������ ������ �迭���� �������� �ϳ��� ����
        int randomIndex = Random.Range(0, itemPrefabs.Length);
        GameObject randomItemPrefab = itemPrefabs[randomIndex];

        // ���õ� �������� ���� ������ ��ġ�� ����
        Instantiate(randomItemPrefab, transform.position, Quaternion.identity);
    }
}
