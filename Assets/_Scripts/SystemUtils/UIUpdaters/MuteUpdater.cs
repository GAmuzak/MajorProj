using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteUpdater : MonoBehaviour
{
    private Toggle toggle;
    private Volume volume;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        volume = FindObjectOfType<Volume>();
    }

    private void OnEnable()
    {
        Mute.onMuteToggle += Updater;
    }
    
    private void OnDisable()
    {
        Mute.onMuteToggle -= Updater;
    }

    private void Updater(bool state)
    {
        toggle.isOn = state;
    }
}
