using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    [Range(0.01f,0.5f)] [SerializeField] private float sensitivity;
    
    private float prevVal;
    private HandGesture inputTigger;
    
    public float CurrentVal => AudioListener.volume;
    public float Sensitivity => sensitivity;

    public void Adjust(float val)
    {
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
