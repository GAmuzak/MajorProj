using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderUpdater : MonoBehaviour
{
    private Slider slider;
    private Volume volume;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = 1f;
        volume = FindObjectOfType<Volume>();
    }

    private void Update()
    {
        slider.normalizedValue = volume.CurrentVal;
    }
}
