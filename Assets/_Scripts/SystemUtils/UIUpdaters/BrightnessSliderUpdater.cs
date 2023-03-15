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

    private void OnEnable()
    {
        BrightnessChange.OnBrightnessChange += Updater;
    }

    private void OnDisable()
    {
        BrightnessChange.OnBrightnessChange -= Updater;
    }

    private void Updater(float newVal)
    {
        slider.value = newVal;
    }
}
