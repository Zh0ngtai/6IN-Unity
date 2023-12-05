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

    void Start()
    {
        startPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        SetPaddleWidth(originalWidth);
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
    }
    public void SetPaddleWidth(float width)
    {
        // 최소 너비와 최대 너비 사이의 값으로 제한
        float clampedWidth = Mathf.Clamp(width, 0.1f, maxWidth);

        Vector3 scale = transform.localScale;
        scale.x = clampedWidth;
        transform.localScale = scale;
    }


    // 사운드 재생 함수
    private void PlaySound(AudioClip sound)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }

}
