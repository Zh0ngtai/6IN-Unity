using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public float sizeIncreaseAmount = 1f;



    // 아이템의 효과를 구현
    // 패들에 어떤 변화를 가할지 여기에 작성
    // 추가 구현요소 공간
    // 예: 패들 크기 증가, 속도 증가, 무기 강화 등
    // give For You ('ㅗ'b)
    // 아이템의 효과를 패들에 적용
    public void ActivateItemEffect(Paddle paddle)
    {
        // 아이템의 효과를 패들에 적용
        IncreasePaddleSize(paddle);

        // 아이템 사용 후 자신을 파괴
        Destroy(gameObject);
    }

    private void IncreasePaddleSize(Paddle paddle)
    {
        // 패들 크기를 10 증가시킴
        Vector3 currentScale = paddle.transform.localScale;
        float newSize = currentScale.x + 100f;
        paddle.transform.localScale = new Vector3(newSize, currentScale.y, currentScale.z);
    }





}

