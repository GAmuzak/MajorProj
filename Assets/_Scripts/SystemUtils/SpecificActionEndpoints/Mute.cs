﻿using System;
using UnityEngine;

public class Mute : MonoBehaviour, IInteractable
{
    [SerializeField] private bool state=false;
    
    private Volume volume;
    private bool canMute=true;
    
    private void Awake()
    {
        volume = transform.parent.GetComponent<Volume>();
    }

    public void Interact()
    {
        if (!canMute) return;
        volume.ToggleMute(!state);
        state = !state;
        canMute = false;
    }

    public void Complete()
    {
        canMute = true;
    }
}