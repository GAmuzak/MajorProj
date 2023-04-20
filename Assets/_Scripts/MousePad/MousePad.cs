using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePad : MonoBehaviour
{
    public static event Action<Vector2> OnCursorPositionChanged;
    public static event Action OnFinished; 

    [SerializeField] private float outputSensitivity = 0.1f;
    [SerializeField] private int cursorSensitivity = 10;
    [SerializeField] private float distanceFromFist;
    [SerializeField] private Transform cursor;
    
    private Vector3 handStartPosition;
    private Vector3 handStartDirection;
    private bool active;

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void TrackCursor(Vector3 handPosition, Vector3 rayDirection)
    {
        if (!active)
        {
            SetPlanePositionAndRotation(handPosition, rayDirection);
            handStartPosition = handPosition.GetXY();
            handStartDirection = rayDirection.GetXY();
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
            active = true;
        }
        else
        {
            UpdateCursorPosition(handPosition, rayDirection);
        }
    }
    
    private void SetPlanePositionAndRotation(Vector3 handPosition, Vector3 rayDirection)
    {
        rayDirection.Normalize();
        Transform mousePadTransform = transform;
        mousePadTransform.forward = -rayDirection;
        mousePadTransform.position = handPosition + rayDirection * distanceFromFist;
        cursor.rotation = mousePadTransform.rotation;
        cursor.localPosition = Vector3.zero;
    }

    private void UpdateCursorPosition(Vector3 handPosition, Vector3 rayDirection)
    {
        
        cursor.localPosition = cursorSensitivity * ((handPosition - handStartPosition).GetXY() + (rayDirection - handStartDirection).GetXY());
        cursor.SetLocalPositionX(-cursor.localPosition.x);
        cursor.SetLocalPositionZ(0);
        Vector2 moveVector = new Vector2(cursor.localPosition.x, cursor.localPosition.y)*outputSensitivity;
        OnCursorPositionChanged?.Invoke(moveVector);
    }
    
    public void Reset()
    {
        active = false;
        cursor.localPosition = Vector3.zero;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        OnFinished?.Invoke();
    }
}
