using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessSliderUpdater : MonoBehaviour
{
    private Brightness brightness;
    private Slider slider;

    private void Awake()
    {
        brightness = FindObjectOfType<Brightness>();
        slider = GetComponent<Slider>();
        slider.maxValue = 2f;
        slider.value = 1f;
    }

    private void OnDisable()
    {
        // enabled = true;
    }

    private void Update()
    {
        Debug.Log(brightness.CurrentVal);
        slider.value = brightness.CurrentVal;
    }
}
