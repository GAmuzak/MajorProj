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
        brightness=transform.parent.GetComponent<Brightness>();
        upOrDown = state == IncreaseOrDecrease.Increase ? 1 : -1;
    }

    public override void Interact()
    {
        brightnessCanvasGroup.alpha = LeanTween.linear(brightnessCanvasGroup.alpha, 1f, 0.1f);
        float newVal = brightness.CurrentVal+ upOrDown*brightness.Sensitivity;
        brightness.Adjust(newVal);
        OnBrightnessChange?.Invoke(newVal);
    }

    public override void Complete()
    {
        brightnessCanvasGroup.alpha = LeanTween.linear(brightnessCanvasGroup.alpha, 0f, 0.1f);
    }
}
