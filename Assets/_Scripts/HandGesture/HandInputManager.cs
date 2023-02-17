using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.iOS;

public class HandInputManager : MonoBehaviour
{
    [SerializeField] private HandGestureIdentifier[] gestureIdentifiers;

    public static UnityEvent<SystemAction, bool> activateGesture = new UnityEvent<SystemAction, bool>();
    public static UnityEvent<SystemAction, bool> deactivateGesture = new UnityEvent<SystemAction, bool>();
    public static SystemAction passedAction;

    private Timer gestureDeselectCoolDown = new Timer();
    void Update()
    {
        
    }

    public static void ActivateGesture(SystemAction executeAction, bool isLeftHand)
    {
        passedAction = executeAction;
        Debug.Log(passedAction);
        ServiceWrapper.Instance.ExecuteServiceUtil(passedAction);
    }
    
    public static void DeactivateGesture(SystemAction executeAction, bool isLeftHand)
    {
        
        ServiceWrapper.Instance.ExecuteServiceUtil(passedAction);
    }
    
}

[Serializable]
public enum HandGesture
{
    NULL = -1,
    ThumbsUp
}
