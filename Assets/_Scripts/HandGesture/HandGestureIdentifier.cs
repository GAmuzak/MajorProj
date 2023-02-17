using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Events;

public class HandGestureIdentifier : MonoBehaviour
{
    public SystemAction utilityGesture;
    public bool isLeftHand;
    private SelectorUnityEventWrapper selectorEvent;
    void Start()
    {
        Debug.Log($"{gameObject.name}: {utilityGesture}");
    }

    public void SelectedGesture()
    {
        Debug.Log(utilityGesture);
        HandInputManager.ActivateGesture(utilityGesture, isLeftHand);
    }
    
    public void UnSelectedGesture()
    {
        
        HandInputManager.DeactivateGesture(utilityGesture, isLeftHand);
    }
    
}
