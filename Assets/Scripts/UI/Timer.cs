using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float CoolTime = 60f;
    private float UpdateTime = 0.0f;
  
    public Image Slider;
    private void Update()
    {
        if(UpdateTime > CoolTime)
        {
            UpdateTime = 0.0f;
            Slider.fillAmount = 0.0f;
        }
        else
        {
            UpdateTime = UpdateTime + Time.deltaTime;
            Slider.fillAmount = 1.0f - (Mathf.Lerp(0, 100, UpdateTime/CoolTime) / 100);
        }
    }



}
