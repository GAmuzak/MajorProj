using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BrightnessChange : InteractableMonoBehaviour
{
    public static event Action<float> OnBrightnessChange;
    private CanvasGroup brightnessCanvasGroup;
    [SerializeField] private IncreaseOrDecrease state;

    private Brightness brightness;
    private int upOrDown;

    private void Awake()
    {
        brightness = transform.parent.GetComponent<Brightness>();
        brightnessCanvasGroup = brightness.brightnessCanvasGroup;

        upOrDown = state switch
        {
            IncreaseOrDecrease.Increase => 1,
            IncreaseOrDecrease.Decrease => -1,
            IncreaseOrDecrease.Neutral => 0,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public override void Interact()
    {
        brightnessCanvasGroup.alpha = 1f;
        float newVal = brightness.CurrentVal+ upOrDown*brightness.Sensitivity;
        brightness.Adjust(newVal);
        OnBrightnessChange?.Invoke(newVal);
    }

    public override void Complete()
    {
        brightnessCanvasGroup.alpha = 0f;
    }
}
