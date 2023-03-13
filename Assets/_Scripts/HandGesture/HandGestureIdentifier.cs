using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Events;

public class HandGestureIdentifier : MonoBehaviour
{
    public SystemAction utilityGesture;
    public GestureContinuity gestureContinuity;
    private SelectorUnityEventWrapper selectorEvent;
    void Start()
    {
        Debug.Log($"{gameObject.name}: {utilityGesture}");
    }

    public void SelectedGesture()
    {
        Debug.Log(utilityGesture);
        HandInputManager.ActivateGesture(utilityGesture, gestureContinuity);
    }
    
    public void UnSelectedGesture()
    {
        Debug.Log($"{"Unselected"}: {utilityGesture}");
        HandInputManager.DeactivateGesture(utilityGesture);
    }
    
}

public enum GestureContinuity
{
    Discrete = 0,
    Continuous = 1
}
