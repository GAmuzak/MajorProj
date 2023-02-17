using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessChange : MonoBehaviour, IInteractable
{
    [SerializeField] private IncreaseOrDecrease state;

    private Brightness brightness;
    private int upOrDown;

    private void Awake()
    {
        brightness=transform.parent.GetComponent<Brightness>();
        upOrDown = state == IncreaseOrDecrease.Increase ? 1 : -1;
    }

    public void Interact()
    {
        brightness.Adjust(brightness.CurrentVal+ upOrDown*brightness.Sensitivity);
    }

    public void Complete()
    {
        //Not Relevant yet
    }
}
