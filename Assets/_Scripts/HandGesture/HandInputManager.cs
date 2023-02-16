using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandInputManager : MonoBehaviour
{
    [SerializeField] private HandGestureIdentifier[] gestureIdentifiers;

    public static UnityEvent<HandGestures, bool> activateGesture = new UnityEvent<HandGestures, bool>();
    public static UnityEvent<HandGestures, bool> deactivateGesture = new UnityEvent<HandGestures, bool>();
    // Start is called before the first frame update
    void Start()
    {
        activateGesture.AddListener(ActivateGesture);
        deactivateGesture.AddListener(DeactivateGesture); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActivateGesture(HandGestures currentHandGesture, bool isLeftHand)
    {
        Debug.Log(currentHandGesture);
        Debug.Log(isLeftHand);
    }
    
    private void DeactivateGesture(HandGestures currentHandGesture, bool isLeftHand)
    {
        Debug.Log(currentHandGesture);
        Debug.Log(isLeftHand);
    }

    private void OnDestroy()
    {
        activateGesture.RemoveListener(ActivateGesture);
        deactivateGesture.RemoveListener(DeactivateGesture); 
    }
}

[Serializable]
public enum HandGestures
{
    NULL = -1,
    ThumbsUp
}
