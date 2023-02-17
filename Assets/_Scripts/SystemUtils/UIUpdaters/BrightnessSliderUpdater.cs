using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessSliderUpdater : MonoBehaviour
{
    private Slider slider;
    private Brightness brightness;

    private void Awake()
    {
        brightness = FindObjectOfType<Brightness>();
        slider = GetComponent<Slider>();
        slider.maxValue = 1f;
    }

    private void Update()
    {
        slider.normalizedValue = brightness.CurrentVal;
    }
}
