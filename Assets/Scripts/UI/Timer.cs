using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float CoolTime { get; set; }
    private float coolTime = 60;
    public float UpdateTime { get { return updateTime; } set { if (value > 0) { updateTime = value; } else { updateTime = 0; } } }
    private float updateTime = 0;

    public Image Slider;
    private void Update()
    {
        if(updateTime > coolTime)
        {
            updateTime = 0.0f;
            Slider.fillAmount = 0.0f;
        }
        else
        {
            updateTime = updateTime + Time.deltaTime;
            Slider.fillAmount = 1.0f - (Mathf.Lerp(0, 100, updateTime/coolTime) / 100);
        }
    }



}
