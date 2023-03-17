using Oculus.Interaction;
using UnityEngine;

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
        HandInputManager.Instance.ActivateGesture(utilityGesture, gestureContinuity);
        if(gestureIconManager.FunctionToIconManager.ContainsKey(this))
            gestureIconManager.FunctionToIconManager[this].ChangeTint(1f);
    }
    
    public void UnSelectedGesture()
    {
        Debug.Log($"{"Unselected"}: {utilityGesture}");
        HandInputManager.Instance.DeactivateGesture(utilityGesture);
        if(gestureIconManager.FunctionToIconManager.ContainsKey(this))
            gestureIconManager.FunctionToIconManager[this].ChangeTint(0.5f);
    }
    
}

public enum GestureContinuity
{
    Discrete = 0,
    Continuous = 1
}
