using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BillBoard : MonoBehaviour
{
    public bool IsEnabled;
    
    private Transform cam;
    private SpriteRenderer sprite;

    private void Awake()
    {
        if (Camera.main != null) cam = Camera.main.gameObject.transform;
        sprite = GetComponent<SpriteRenderer>();
    }

    public void ChangeTint(bool state)
    {
        Color imageColor = sprite.color;
        imageColor.a = state ? 50 : 100;
        sprite.color = imageColor;
    }
    
    private void Update()
    {
        if (!IsEnabled) return;
        transform.LookAt(transform.position+cam.forward);
    }
}