using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    [Range(0.01f,0.5f)] [SerializeField] private float sensitivity;
    
    private float prevVal;
    public CanvasGroup volumeCanvasGroup;

    public float CurrentVal => AudioListener.volume;
    public float Sensitivity => sensitivity;

    private void Awake()
    {
        volumeCanvasGroup = transform.parent.GetComponent<CanvasGroup>();
    }

    public void Adjust(float val)
    {
        if (val > 1f) return;
        AudioListener.volume = val;
    }

    public void ToggleMute(bool state)
    {
        if (state)
        {
            prevVal = AudioListener.volume;
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = prevVal;
        }
    }
}
