using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteUpdater : MonoBehaviour
{
    private Toggle toggle;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
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
        Debug.Log(state);
        toggle.isOn = state;
    }
}
