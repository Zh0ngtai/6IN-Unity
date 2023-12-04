using UnityEngine;

public class Bat : MonoBehaviour
{
    public float speed = 5f;
    private bool isMovingRight = true; // 이동 방향을 나타내는 플래그
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 좌우로 이동
        float horizontalMovement = isMovingRight ? 1f : -1f;
        rb.velocity = new Vector2(horizontalMovement * speed, rb.velocity.y);

        // 벽에 부딪혔을 때 이동 방향을 반전하고 스케일을 반전하여 뒤로 돌도록 함
        if (isMovingRight && horizontalMovement < 0f || !isMovingRight && horizontalMovement > 0f)
        {
            isMovingRight = !isMovingRight;
            Flip();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 벽에 부딪혔을 때 이동 방향을 반전
        if (collision.gameObject.CompareTag("Wall"))
        {
            isMovingRight = !isMovingRight;
            Flip();
        }
    }

    void Flip()
    {
        Vector2 newScale = transform.localScale;
        newScale.x *= -1f;
        transform.localScale = newScale;
    }
}