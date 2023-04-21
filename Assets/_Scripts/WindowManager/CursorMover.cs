using System.Collections.Generic;
using UnityEngine;

public class CursorMover : InteractableMonoBehaviour
{
    public Direction moveDirection;

    private float sensitivity;
    private WindowManager windowManager;
    
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
        
    }

    public override void Interact()
    {
        Window currentWindow = windowManager.SelectedWindow;
        Vector2Int targetWindowIndex = currentWindow.containerIndex + directionToVector[moveDirection];
        
        bool isXInRange = targetWindowIndex.x < windowManager.numberOfWindows.x && targetWindowIndex.x >= 0;
        bool isYInRange = targetWindowIndex.y < windowManager.numberOfWindows.y && targetWindowIndex.y >= 0;
        if (!isXInRange || !isYInRange) return; // opposite of (isXInRange && IsYInRange) 

        Window targetWindow = windowManager.Windows[targetWindowIndex.x, targetWindowIndex.y];
        windowManager.SelectWindow(targetWindow);
    }
    
    public override void Complete()
    {
        
    }

    private void OnDisable()
    {
        
    }
}

public enum Direction
{
    UP = 0,
    DOWN = 1,
    LEFT = 2,
    RIGHT = 3
}
