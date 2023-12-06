using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    public Rigidbody2D rb;
    float X, Y;
    public AudioClip brickHitSound;  
    public AudioClip paddleHitSound;
    private GameManager gameManager;
    const float C_Radian = 180f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameManager.I; // 게임 매니저 참조 얻기
        Vector2 direction = new Vector2(Random.Range(-0.5f, 0.5f), 0.5f);
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }


    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -10)
        {
            Destroy(gameObject);
            GameManager.I.CheckBalls();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("TopWall"))
        {
            Vector3 tmp = transform.eulerAngles;
            tmp.z = C_Radian - tmp.z;
            transform.eulerAngles = tmp;
        }
        else if (collision.collider.CompareTag("Wall"))
        {
            Vector3 tmp = transform.eulerAngles;
            tmp.z = (C_Radian * 2) - tmp.z;
            transform.eulerAngles = tmp;
        }

        if (collision.gameObject.CompareTag("Brick"))
        {
            // 블럭에 부딪힐 때 소리를 재생
            PlaySound(brickHitSound);
        }
        else if (collision.gameObject.CompareTag("Paddle"))
        {
            // 패들에 부딪힐 때 소리를 재생
            PlaySound(paddleHitSound);
        }
    }

    private void PlaySound(AudioClip sound)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }




}
