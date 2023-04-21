using System;
using UnityEngine;

public class TheOtherTester : MonoBehaviour
{
    private Vector3 startPosition;
    private bool firstCall = true;

    private void OnEnable()
    {
        MousePad.OnCursorPositionChanged += MoveObject;
        MousePad.OnFinished += Finished;
    }

    private void OnDisable()
    {
        MousePad.OnCursorPositionChanged -= MoveObject;
        MousePad.OnFinished -= Finished;
    }
    
    private void MoveObject(Vector2 obj)
    {
        if (firstCall)
        {
            startPosition = transform.position;
            firstCall = false;
        }
        transform.position = new Vector3(startPosition.x-obj.x, startPosition.y+obj.y, startPosition.z);
    }
    
    private void Finished()
    {
        firstCall = true;
    }
}
