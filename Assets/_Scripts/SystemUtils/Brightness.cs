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

    private AutoExposure exposure;
    
    public float Sensitivity => sensitivity;

    public float CurrentVal => exposure.keyValue.value;

    private void Awake()
    {
        brightness.TryGetSettings(out exposure);
    }

    public void Adjust(float val)
    {
        exposure.keyValue.value = val > 0 ? val : 0.02f;
    }
}
