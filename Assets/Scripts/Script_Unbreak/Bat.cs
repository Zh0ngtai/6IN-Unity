using UnityEngine;

public class Bat : MonoBehaviour
{
    public float speed = 5f;
    private bool isMovingRight = true; // �̵� ������ ��Ÿ���� �÷���
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �¿�� �̵�
        float horizontalMovement = isMovingRight ? 1f : -1f;
        rb.velocity = new Vector2(horizontalMovement * speed, rb.velocity.y);

        // ���� �ε����� �� �̵� ������ �����ϰ� �������� �����Ͽ� �ڷ� ������ ��
        if (isMovingRight && horizontalMovement < 0f || !isMovingRight && horizontalMovement > 0f)
        {
            isMovingRight = !isMovingRight;
            Flip();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ���� �ε����� �� �̵� ������ ����
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