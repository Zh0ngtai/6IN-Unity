using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle4 : MonoBehaviour
{
    
    public float speed; // 이동 속도 변수

    void Update()
    {
        // 마우스의 X축 위치를 가져옴
        float mouseX = Input.mousePosition.x;

        // 화면의 가로 길이를 기준으로 비율을 계산
        float screenWidth = Screen.width;
        float normalizedMouseX = (mouseX / screenWidth) * 2 - 1;

        // x축으로만 이동시킴
        transform.Translate(new Vector3(normalizedMouseX * speed * Time.deltaTime, 0, 0));
    }
}
