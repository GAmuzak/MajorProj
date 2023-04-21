using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class Scroll : InteractableMonoBehaviour
{
    public Direction moveDirection;
    public float sensitivity;
    private Window mapWindow;
    [SerializeField] private ScrollRect scrollRect;
    private int scrollDir;
    private readonly Dictionary<Direction, Vector2Int> directionToVector = new Dictionary<Direction, Vector2Int>()
    {
        { Direction.UP, Vector2Int.up },
        { Direction.DOWN, Vector2Int.down },
        { Direction.LEFT, Vector2Int.left },
        { Direction.RIGHT, Vector2Int.right },
    };
    // Start is called before the first frame update
    void Start()
    {
        mapWindow = GetComponent<Window>();
        scrollRect = GetComponentInChildren<ScrollRect>();
    }

    public override void Interact()
    {
        if(!mapWindow.isOpen) return;
        scrollDir = moveDirection is Direction.UP or Direction.RIGHT ? 1 : -1;
        float contentHeight = scrollRect.content.rect.height;
        float contentWidth = scrollRect.content.rect.width;
        float contentShift = sensitivity * scrollDir;
        switch (moveDirection)
        {
            case Direction.UP:
                
                scrollRect.verticalNormalizedPosition += contentShift / contentHeight;
                break;
            case Direction.DOWN:
                scrollRect.verticalNormalizedPosition += contentShift / contentHeight;
                break;
            case Direction.LEFT:
                scrollRect.horizontalNormalizedPosition += contentShift / contentWidth;
                break;
            case Direction.RIGHT:
                scrollRect.horizontalNormalizedPosition += contentShift / contentWidth;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    

    public override void Complete()
    {
        
    }
}
