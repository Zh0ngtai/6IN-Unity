using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool Palyer1;
    public float speed;
    public Rigidbody2D rigidbody;

    public KeyCode Right;
    public KeyCode Left;

    private float movement;
    private Vector3 startPosition;

    public AudioClip itemPickupSound;


    public float originalWidth = 2.0f; // 초기 Paddle의 너비
    public float maxWidth = 4.0f; // 최대 Paddle의 너비

    public GameObject ballPrefab; // 추가될 복제할 공의 프리팹
    public int maxBalls = 3; // 최대 볼 개수
    private List<GameObject> ball; // 현재 생성된 볼을 저장할 리스트

    void Start()
    {
        startPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        SetPaddleWidth(originalWidth);

        // 볼 초기화
        ball = new List<GameObject>();
        SpawnBall(); // 초기에 한 개의 볼 생성
    }


    void Update()
    {
        movement = 0f;
        if (Input.GetKey(Right)) { movement += 1f; }
        if (Input.GetKey(Left)) { movement -= 1f; }
        rigidbody.velocity = new Vector2( movement * speed,0);


    }

    public void Reset()
    {
        rigidbody.velocity = Vector3.zero;
        transform.position = startPosition;
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ItemEnlargePaddle"))
        {
            ItemEnlargePaddle enlargeItem = other.GetComponent<ItemEnlargePaddle>();
            if (enlargeItem != null)
            {
                SetPaddleWidth(originalWidth + enlargeItem.enlargementAmount);
                Destroy(other.gameObject); // 아이템 소멸
                PlaySound(itemPickupSound); // 아이템 획득 사운드 재생
            }
        }
        else if (other.CompareTag("ItemShrinkPaddle"))
        {
            ItemShrinkPaddle shrinkItem = other.GetComponent<ItemShrinkPaddle>();
            if (shrinkItem != null)
            {
                float newWidth = Mathf.Max(originalWidth - shrinkItem.reductionAmount, 0.1f);
                SetPaddleWidth(newWidth);
                Destroy(other.gameObject); // 아이템 소멸
                PlaySound(itemPickupSound); // 아이템 획득 사운드 재생
            }
        }
        else if (other.CompareTag("ItemAddBall"))
        {
            ItemAddBall addBallItem = other.GetComponent<ItemAddBall>();
            if (addBallItem != null)
            {
                // 공의 개수가 최대 볼 개수 미만이면
                if (ball.Count < maxBalls)
                {
                    SpawnBall(); // 새로운 볼 생성
                    Destroy(other.gameObject); // 아이템 소멸
                    PlaySound(itemPickupSound); // 아이템 획득 사운드 재생
                }
            }
        }
        else if (other.CompareTag("ItemAddTime"))
        {
            ItemAddTime ItemTime = other.GetComponent<ItemAddTime>();
            if (ItemTime != null)
            {

                Destroy(other.gameObject); // 아이템 소멸
                PlaySound(itemPickupSound); // 아이템 획득 사운드 재생
            }
        }
    }
    public void SetPaddleWidth(float width)
    {
        // 최소 너비와 최대 너비 사이의 값으로 제한
        float clampedWidth = Mathf.Clamp(width, 0.1f, maxWidth);

        Vector3 scale = transform.localScale;
        scale.x = clampedWidth;
        transform.localScale = scale;
    }

    // 새로운 볼을 생성하는 메서드
    void SpawnBall()
    {
        GameObject newBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        ball.Add(newBall); // 생성된 볼을 리스트에 추가
    }

    // 사운드 재생 함수
    private void PlaySound(AudioClip sound)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }

}
