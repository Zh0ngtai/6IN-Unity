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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(Random.insideUnitSphere * speed, ForceMode2D.Impulse);
    }


    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -10)
        {
            Destroy(gameObject);
            GameManager.I.LoseGame();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
