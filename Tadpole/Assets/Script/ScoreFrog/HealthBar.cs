using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private void Start()
    {
        slider.maxValue = 20;
        slider.value = 20;
        fill.color = gradient.Evaluate(1f);
        Invoke("decreaseHealth", 1);
    }
    /*private void Update()
    {
        if (slider.value >= 20)     //최대체력
            slider.value = 20;
    }*/
    public void decreaseHealth()
    {
        slider.value -= 1;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        Invoke("decreaseHealth", 1);
    }
    public void getHealth()
    {
        slider.value += 10;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
