
using System;
using UnityEngine;

public class Tester : MonoBehaviour
{
    [SerializeField] private RaycastToMouse raycastToMouse;

    private bool isActive = false;

    public void Activate(out string message)
    {
        isActive = true;
        message = transform.forward.ToString();
    }
    
    public void Deactivate()
    {
        isActive = false;
        raycastToMouse.Reset();
    }

    private void Update()
    {
        if (!isActive) return;
        raycastToMouse.CallMousePad(transform.position, transform.forward);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = isActive ? Color.green : Color.red;
        Gizmos.DrawRay(transform.position, transform.forward);
    }
}
