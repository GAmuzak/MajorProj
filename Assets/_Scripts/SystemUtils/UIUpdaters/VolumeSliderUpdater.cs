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
    
    private void OnEnable()
    {
        VolumeChange.OnVolumeChange += Updater;
    }

    private void OnDisable()
    {
        VolumeChange.OnVolumeChange -= Updater;
    }

    private void Updater(float newVal)
    {
        slider.normalizedValue = newVal;
    }
}
