using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.Input;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class GestureIcon : MonoBehaviour
{
    [SerializeField] private Handedness handType;
    [SerializeField] private OVRSkeleton.BoneId targetBoneID;
    
    
    private Transform cam;
    private SpriteRenderer sprite;
    private Color imageColor = new Color(255,255,255,0);
    private GestureIconManager gestureIconManager;

    private OVRSkeleton targetHandData;
    private OVRBone targetBone;
    private void Awake()
    {
        cam = Camera.main.gameObject.transform;
        sprite = GetComponent<SpriteRenderer>();
        imageColor.a = 0f;
        sprite.color = imageColor;
        gestureIconManager = GetComponentInParent<GestureIconManager>();
    }

    private void Start()
    {
        
        
        //Debug.Log(targetBone.Transform.gameObject.name);
    }

    private void TryGetBoneData()
    {
        switch (handType)
        {
            case Handedness.Left:
                targetHandData = gestureIconManager.leftHandSkeleton;
                targetBone = targetHandData.Bones[(int)targetBoneID];
                break;
            case Handedness.Right:
                targetHandData = gestureIconManager.rightHandSkeleton;
                targetBone = targetHandData.Bones[(int)targetBoneID];
                break;
        }
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
        if (targetBone == null)
        {
            TryGetBoneData();
            return;
        }
        transform.position = targetBone.Transform.position;
        transform.forward = -cam.forward;
    }
}