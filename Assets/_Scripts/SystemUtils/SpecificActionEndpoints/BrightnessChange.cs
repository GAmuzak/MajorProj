using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessChange : InteractableMonoBehaviour
{
    public static event Action<float> OnBrightnessChange;
    [SerializeField] private IncreaseOrDecrease state;

    private Brightness brightness;
    private int upOrDown;

    private void Awake()
    {
        brightness=transform.parent.GetComponent<Brightness>();
        upOrDown = state == IncreaseOrDecrease.Increase ? 1 : -1;
    }

    public override void Interact()
    {
        float newVal = brightness.CurrentVal+ upOrDown*brightness.Sensitivity;
        brightness.Adjust(newVal);
        OnBrightnessChange?.Invoke(newVal);
    }

    public override void Complete()
    {
        //Not Relevant yet
    }
}
