using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandInputManager : MonoBehaviour
{
    [SerializeField] private HandGestureIdentifier[] gestureIdentifiers;

    public static UnityEvent<HandGesture, bool> activateGesture = new UnityEvent<HandGesture, bool>();
    public static UnityEvent<HandGesture, bool> deactivateGesture = new UnityEvent<HandGesture, bool>();
    // Start is called before the first frame update
    void Start()
    {
        activateGesture.AddListener(ActivateGesture);
        // activateGesture.AddListener();
        deactivateGesture.AddListener(DeactivateGesture); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActivateGesture(HandGesture currentHandGesture, bool isLeftHand)
    {
        Debug.Log(currentHandGesture);
        Debug.Log(isLeftHand);
    }
    
    private void DeactivateGesture(HandGesture currentHandGesture, bool isLeftHand)
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
public enum HandGesture
{
    NULL = -1,
    ThumbsUp
}
