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


    public float originalWidth = 2.0f; // �ʱ� Paddle�� �ʺ�
    public float maxWidth = 4.0f; // �ִ� Paddle�� �ʺ�

    public GameObject ballPrefab; // �߰��� ������ ���� ������
    public int maxBalls = 3; // �ִ� �� ����
    private List<GameObject> ball; // ���� ������ ���� ������ ����Ʈ

    void Start()
    {
        startPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        SetPaddleWidth(originalWidth);

        // �� �ʱ�ȭ
        ball = new List<GameObject>();
        SpawnBall(); // �ʱ⿡ �� ���� �� ����
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
                Destroy(other.gameObject); // ������ �Ҹ�
                PlaySound(itemPickupSound); // ������ ȹ�� ���� ���
            }
        }
        else if (other.CompareTag("ItemShrinkPaddle"))
        {
            ItemShrinkPaddle shrinkItem = other.GetComponent<ItemShrinkPaddle>();
            if (shrinkItem != null)
            {
                float newWidth = Mathf.Max(originalWidth - shrinkItem.reductionAmount, 0.1f);
                SetPaddleWidth(newWidth);
                Destroy(other.gameObject); // ������ �Ҹ�
                PlaySound(itemPickupSound); // ������ ȹ�� ���� ���
            }
        }
        else if (other.CompareTag("ItemAddBall"))
        {
            ItemAddBall addBallItem = other.GetComponent<ItemAddBall>();
            if (addBallItem != null)
            {
                // ���� ������ �ִ� �� ���� �̸��̸�
                if (ball.Count < maxBalls)
                {
                    SpawnBall(); // ���ο� �� ����
                    Destroy(other.gameObject); // ������ �Ҹ�
                    PlaySound(itemPickupSound); // ������ ȹ�� ���� ���
                }
            }
        }
        else if (other.CompareTag("ItemAddTime"))
        {
            ItemAddTime ItemTime = other.GetComponent<ItemAddTime>();
            if (ItemTime != null)
            {

                Destroy(other.gameObject); // ������ �Ҹ�
                PlaySound(itemPickupSound); // ������ ȹ�� ���� ���
            }
        }
    }
    public void SetPaddleWidth(float width)
    {
        // �ּ� �ʺ�� �ִ� �ʺ� ������ ������ ����
        float clampedWidth = Mathf.Clamp(width, 0.1f, maxWidth);

        Vector3 scale = transform.localScale;
        scale.x = clampedWidth;
        transform.localScale = scale;
    }

    // ���ο� ���� �����ϴ� �޼���
    void SpawnBall()
    {
        GameObject newBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        ball.Add(newBall); // ������ ���� ����Ʈ�� �߰�
    }

    // ���� ��� �Լ�
    private void PlaySound(AudioClip sound)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }

}
