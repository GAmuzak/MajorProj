using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppScroller : MonoBehaviour
{
    [SerializeField] private float lowerScale = 0.4f;
    [SerializeField] private float moveAmount;
    [SerializeField] private LeanTweenType animType;
    [SerializeField] private float animTime;
    
    

    private RectTransform content;
    private bool tabModeIsActive = false;

    private readonly float time = 0.5f;
    private readonly List<LayoutElement> apps = new List<LayoutElement>();

    private void Awake()
    {
        content = transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
        tabModeIsActive = false;
    }

    public void CarouselMode()
    {
        content.LeanScale(tabModeIsActive ? Vector3.one * lowerScale : Vector3.one, 0.4f).setEase(animType);
        tabModeIsActive = !tabModeIsActive;
    }
    
    private void ScaleAround(GameObject target, Vector3 pivot, Vector3 newScale)
    {
        Vector3 A = target.transform.localPosition;
        Vector3 B = pivot;
 
        Vector3 C = A - B; // diff from object pivot to desired pivot/origin
 
        float RS = newScale.x / target.transform.localScale.x; // relative scale factor
 
        // calc final position post-scale
        Vector3 FP = B + C * RS;
 
        // finally, actually perform the scale/translation
        target.transform.localScale = newScale;
        target.transform.localPosition = FP;
    }
}
