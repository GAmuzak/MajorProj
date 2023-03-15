using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class HandInputManager : MonoBehaviour
{
    public static UnityEvent<SystemAction, bool> activateGesture = new UnityEvent<SystemAction, bool>();
    public static UnityEvent<SystemAction, bool> deactivateGesture = new UnityEvent<SystemAction, bool>();
    public static SystemAction passedAction;
    public static GestureContinuity continuity;
    private static bool isAnalog;
    void Update()
    {
        if (isAnalog)
        {
            ServiceWrapper.Instance.ExecuteService(passedAction);
        }
    }

    public static void ActivateGesture(SystemAction executeAction, GestureContinuity _continuity)
    {
        passedAction = executeAction;
        isAnalog = _continuity == GestureContinuity.Continuous;
        Debug.Log(passedAction);
        ServiceWrapper.Instance.ExecuteService(passedAction);
    }
    
    public static void DeactivateGesture(SystemAction executeAction)
    {
        Debug.Log($"{"Unselected in Input Manager"}: {executeAction}");
        isAnalog = false;
        ServiceWrapper.Instance.EndService(executeAction);
    }
    
}
