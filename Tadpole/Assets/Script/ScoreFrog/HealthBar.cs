using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        slider.maxValue = 20;
        slider.value = 20;
        Invoke("decreaseHealth", 1);
    }
    public void decreaseHealth()
    {
        slider.value -= 1;
        Invoke("decreaseHealth", 1);
    }
    public void getHealth()
    {
        slider.value += 10;
    }
}
