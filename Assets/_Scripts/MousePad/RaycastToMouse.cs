using System;
using UnityEngine;

public class RaycastToMouse : MonoBehaviour
{
    [SerializeField] private MousePad mousePad;

    public void CallMousePad (Vector3 handPosition, Vector3 direction)
    {
        // Debug.Log(direction);
        mousePad.TrackCursor(handPosition, direction);
    }
    
    public void Reset()
    {
        mousePad.Reset();
    }
}
