using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle4 : MonoBehaviour
{
    
    public float speed; // �̵� �ӵ� ����

    void Update()
    {
        // ���콺�� X�� ��ġ�� ������
        float mouseX = Input.mousePosition.x;

        // ȭ���� ���� ���̸� �������� ������ ���
        float screenWidth = Screen.width;
        float normalizedMouseX = (mouseX / screenWidth) * 2 - 1;

        // x�����θ� �̵���Ŵ
        transform.Translate(new Vector3(normalizedMouseX * speed * Time.deltaTime, 0, 0));
    }
}
