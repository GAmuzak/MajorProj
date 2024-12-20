using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class Brightness : MonoBehaviour
{
    [Range(0.01f,0.5f)] [SerializeField] private float sensitivity;
    [SerializeField] private PostProcessProfile brightness;
    public CanvasGroup brightnessCanvasGroup;

    private AutoExposure exposure;
    
    public float Sensitivity => sensitivity;

    public float CurrentVal => exposure.keyValue.value;

    private void Awake()
    {
        brightness.TryGetSettings(out exposure);
        Debug.Log(exposure);
        brightnessCanvasGroup = transform.parent.GetComponent<CanvasGroup>();
    }

    public void Adjust(float val)
    {
        if (val > 2f) return;
        Debug.Log(val);
        exposure.keyValue.value = val > 0 ? val : 0.02f;
    }
}
