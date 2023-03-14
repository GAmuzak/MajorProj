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
    private GestureIconManager gestureIconManager;
    void Start()
    {
        Debug.Log($"{gameObject.name}: {utilityGesture}");
        gestureIconManager = FindObjectOfType<GestureIconManager>();
    }

    public void SelectedGesture()
    {
        Debug.Log(utilityGesture);
        HandInputManager.ActivateGesture(utilityGesture, gestureContinuity);
        gestureIconManager.FunctionToIconManager[this].ChangeTint(1f);
    }
    
    public void UnSelectedGesture()
    {
        Debug.Log($"{"Unselected"}: {utilityGesture}");
        HandInputManager.DeactivateGesture(utilityGesture);
        gestureIconManager.FunctionToIconManager[this].ChangeTint(0.5f);
    }
    
}

public enum GestureContinuity
{
    Discrete = 0,
    Continuous = 1
}
