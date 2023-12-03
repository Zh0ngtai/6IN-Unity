using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public float sizeIncreaseAmount = 1f;



    // �������� ȿ���� ����
    // �е鿡 � ��ȭ�� ������ ���⿡ �ۼ�
    // �߰� ������� ����
    // ��: �е� ũ�� ����, �ӵ� ����, ���� ��ȭ ��
    // give For You ('��'b)
    // �������� ȿ���� �е鿡 ����
    public void ActivateItemEffect(Paddle paddle)
    {
        // �������� ȿ���� �е鿡 ����
        IncreasePaddleSize(paddle);

        // ������ ��� �� �ڽ��� �ı�
        Destroy(gameObject);
    }

    private void IncreasePaddleSize(Paddle paddle)
    {
        // �е� ũ�⸦ 10 ������Ŵ
        Vector3 currentScale = paddle.transform.localScale;
        float newSize = currentScale.x + 100f;
        paddle.transform.localScale = new Vector3(newSize, currentScale.y, currentScale.z);
    }





}

