using System.Collections;
using System.Collections.Generic;
using DanielLochner.Assets.SimpleScrollSnap;
using UnityEngine;

public class ChangePanel : InteractableMonoBehaviour
{
    public Direction moveDirection;
    private Window window;
    private SimpleScrollSnap scrollBar;
    // Start is called before the first frame update
    void Start()
    {
        window = GetComponent<Window>();
        scrollBar = GetComponentInChildren<SimpleScrollSnap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        if(!window.isOpen) return;
        switch (moveDirection)
        {
            case Direction.RIGHT:
                scrollBar.GoToNextPanel();
                break;
            case Direction.LEFT:
                scrollBar.GoToPreviousPanel();
                break;
        }
    }
    public override void Complete()
    {
       
    }
}
