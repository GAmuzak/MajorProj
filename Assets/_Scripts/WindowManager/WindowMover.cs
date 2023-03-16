using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowMover : InteractableMonoBehaviour
{
    public Direction moveDirection;

    private float sensitivity;
    private WindowManager windowManager;
    private static Window targetWindow;
    
    private readonly Dictionary<Direction, Vector2Int> directionToVector = new Dictionary<Direction, Vector2Int>()
    {
        { Direction.UP, Vector2Int.up },
        { Direction.DOWN, Vector2Int.down },
        { Direction.LEFT, Vector2Int.left },
        { Direction.RIGHT, Vector2Int.right },
    };
    private void Start()
    {
        windowManager = GetComponent<WindowManager>();
        sensitivity = windowManager.sensitivity;
    }

    private void OnEnable()
    {
        WindowManager.OnSelectedWindowChanged += ChangeTargetWindow;
    }

    public override void Interact()
    {
        WindowContainer currentContainer = targetWindow.transform.parent.GetComponentInParent<WindowContainer>();
        Vector2Int targetContainerIndex = currentContainer.containerIndex + directionToVector[moveDirection];
        
        bool isXInRange = targetContainerIndex.x < windowManager.numberOfWindows.x && targetContainerIndex.x >= 0;
        bool isYInRange = targetContainerIndex.y < windowManager.numberOfWindows.y && targetContainerIndex.y >= 0;
        if (!isXInRange || !isYInRange) return; // opposite of (isXInRange && IsYInRange) 

        WindowContainer targetContainer = windowManager.WindowContainer2DArray[targetContainerIndex.x, targetContainerIndex.y];
        if (targetContainer.isOccupied)
        {
            Window occupiedWindow = targetContainer.transform.GetComponentInChildren<Window>();
            SwapWindows(occupiedWindow, targetWindow);
        }
        else
        {
            targetWindow.transform.parent = windowManager.transform;
            targetWindow.transform.LeanMove(targetContainer.transform.position, 0.2f);
            targetWindow.transform.SetParent(targetContainer.transform);
            targetContainer.UpdateOccupancy();
            currentContainer.UpdateOccupancy();
        }

    }

    private void SwapWindows(Window _occupiedWindow, Window _targetWindow)
    {
        WindowContainer currentContainer = targetWindow.transform.parent.GetComponentInParent<WindowContainer>();
        Vector2Int targetContainerIndex = currentContainer.containerIndex + directionToVector[moveDirection];
        WindowContainer targetContainer = windowManager.WindowContainer2DArray[targetContainerIndex.x, targetContainerIndex.y];
        _targetWindow.transform.LeanMove(targetContainer.transform.position, 0.2f);
        _occupiedWindow.transform.LeanMove(currentContainer.transform.position, 0.2f);
        _targetWindow.transform.SetParent(targetContainer.transform);
        _occupiedWindow.transform.SetParent(currentContainer.transform);
        targetContainer.UpdateOccupancy();
        currentContainer.UpdateOccupancy();
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
