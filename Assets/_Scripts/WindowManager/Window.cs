using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window : InteractableMonoBehaviour
{
    public Vector2Int containerIndex;
    public bool isSelected;
    public bool isOpen;
    private Image cursorSprite;
    void Awake()
    {
        cursorSprite = GetComponent<Image>();
        cursorSprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        
    }

    public override void Complete()
    {
        
    }

    public void ActivateCursor(bool activationState)
    {
        cursorSprite.enabled = activationState;
        isSelected = activationState;
    }
    
}

