using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowMover : InteractableMonoBehaviour
{
    public Direction moveDirection;

    private float sensitivity;
    private RectTransform windowTransform;
    private WindowManager windowManager;
    private static Window targetWindow;
    
    private readonly Dictionary<Direction, Vector3> directionToVector = new Dictionary<Direction, Vector3>()
    {
        { Direction.UP, Vector3.up },
        { Direction.DOWN, Vector3.down },
        { Direction.LEFT, Vector3.left },
        { Direction.RIGHT, Vector3.right },
    };
    private void Start()
    {
        windowTransform = GetComponent<RectTransform>();
        windowManager = GetComponent<WindowManager>();
        sensitivity = windowManager.sensitivity;
    }

    private void OnEnable()
    {
        WindowManager.OnSelectedWindowChanged += ChangeTargetWindow;
    }

    public override void Interact()
    {
        targetWindow.transform.position += directionToVector[moveDirection] * sensitivity;
    }

    public override void Complete()
    {
        
    }

    private static void ChangeTargetWindow(Window window)
    {
        targetWindow = window;
    }

    private void OnDisable()
    {
        WindowManager.OnSelectedWindowChanged -= ChangeTargetWindow;
    }
}

public enum Direction
{
    UP = 0,
    DOWN = 1,
    LEFT = 2,
    RIGHT = 3
}
