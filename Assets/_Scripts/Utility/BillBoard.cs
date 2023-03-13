using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class BillBoard : MonoBehaviour
{
    public bool IsEnabled;
    
    private Transform cam;
    private SpriteRenderer sprite;
    private Color imageColor = new Color(255,255,255,0);

    private void Awake()
    {
        if (Camera.main != null) cam = Camera.main.gameObject.transform;
        sprite = GetComponent<SpriteRenderer>();
        imageColor.a = 0f;
        sprite.color = imageColor;
    }

    public void EnableIcon(bool activate)
    {
        imageColor = activate? new Color(1,1,1,0.25f) : new Color(255,255,255,0);
        sprite.color = imageColor;
    }

    public void ChangeTint(float alpha)
    {
        Color imageColor = new Color(1,1,1,alpha);
        sprite.color = imageColor;
    }
    
    private void Update()
    {
        if (!IsEnabled) return;
        transform.forward = -cam.forward;
        //transform.LookAt(transform.position+cam.forward);
    }
}