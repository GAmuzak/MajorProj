using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Events;

public class HandGestureIdentifier : MonoBehaviour
{
    public HandGestures handGesture;
    public bool isLeftHand;
    private SelectorUnityEventWrapper selectorEvent;
    void Start()
    {
        selectorEvent = GetComponent<SelectorUnityEventWrapper>();
        selectorEvent.WhenSelected.AddListener(SelectedGesture);
        selectorEvent.WhenUnselected.AddListener(UnSelectedGesture);
    }

    void SelectedGesture()
    {
        HandInputManager.activateGesture?.Invoke(handGesture, isLeftHand);
    }
    
    void UnSelectedGesture()
    {
        HandInputManager.deactivateGesture?.Invoke(handGesture, isLeftHand);
    }

    private void OnDestroy()
    {
        selectorEvent.WhenSelected.RemoveListener(SelectedGesture);
        selectorEvent.WhenUnselected.RemoveListener(UnSelectedGesture);
    }
}
