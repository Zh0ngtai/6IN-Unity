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


    private float defaultPaddleWidth = 4.0f; // �е��� �⺻ ����
    private float currentPaddleWidth;         // ���� �е��� ����

    // ������ ȿ�� ���� ���� ����
    private bool isItemActive = false;         // ������ ȿ�� Ȱ��ȭ ����




    void Start()
    {
        startPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        currentPaddleWidth = defaultPaddleWidth;
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
        currentPaddleWidth = defaultPaddleWidth;
        isItemActive = false;
    }


    public void ApplyItemEffect(/* � �Ű������� �ʿ������� ���� ���� */)
    {
        // �����ۿ� ���� ȿ���� ����
        // ��: ũ�� ����, �ӵ� ����, ���� ��ȭ ��

        // ���⼭�� �е��� ���̸� �ø��� ȿ���� ���÷� ������ϴ�.
        IncreasePaddleWidth(2.0f); // ��: 2.0f�� ������ ���� �������Դϴ�.

        // ������ ȿ�� Ȱ��ȭ
        isItemActive = true;


        // �������� ���� �� �Ҹ��� ���
        PlaySound(itemPickupSound);
    }

    // ������ ȿ�� ����
    private void ResetPaddleWidth()
    {
        currentPaddleWidth = defaultPaddleWidth;
        isItemActive = false;
    }


    // �е��� ���̸� ������Ű�� �Լ�
    private void IncreasePaddleWidth(float increaseAmount)
    {
        // x �����θ� ���̸� �ø��ϴ�.
        transform.localScale = new Vector3(currentPaddleWidth + increaseAmount, transform.localScale.y, transform.localScale.z);
    }

    // ������ ȿ���� �ߵ��� �� ������ ���� ���


    // ���� ��� �Լ�
    private void PlaySound(AudioClip sound)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }

}
