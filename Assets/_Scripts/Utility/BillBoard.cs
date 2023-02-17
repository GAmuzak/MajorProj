using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BillBoard : MonoBehaviour
{
    public bool IsEnabled;
    
    private Transform cam;
    private Image image;

    private void Awake()
    {
        if (Camera.main != null) cam = Camera.main.gameObject.transform;
        image = GetComponent<Image>();
    }

    public void ChangeTint(bool state)
    {
        Color imageColor = image.color;
        imageColor.a = state ? 50 : 100;
        image.color = imageColor;
    }
    
    private void Update()
    {
        if (!IsEnabled) return;
        transform.LookAt(transform.position+cam.forward);
    }
}