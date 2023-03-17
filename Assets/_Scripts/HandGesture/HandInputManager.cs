using UnityEngine;
using Utilities;

public class HandInputManager : SingletonMonoBehavior<HandInputManager>
{
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

    public void ActivateGesture(SystemAction executeAction, GestureContinuity _continuity)
    {
        passedAction = executeAction;
        isAnalog = _continuity == GestureContinuity.Continuous;
        Debug.Log(passedAction);
        ServiceWrapper.Instance.ExecuteService(passedAction);
    }
    
    public void DeactivateGesture(SystemAction executeAction)
    {
        Debug.Log($"Unselected in Input Manager: {executeAction}");
        isAnalog = false;
        ServiceWrapper.Instance.EndService(executeAction);
        
    }



}
