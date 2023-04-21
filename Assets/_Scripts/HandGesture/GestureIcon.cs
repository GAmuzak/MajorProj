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
        
    }

    private void TryGetBoneData()
    {
        switch (handType)
        {
            case Handedness.Left:
                targetHandData = gestureIconManager.leftHandSkeleton;
                if(targetHandData.Bones[(int)targetBoneID] != null)
                    targetBone = targetHandData.Bones[(int)targetBoneID];
                break;
            case Handedness.Right:
                targetHandData = gestureIconManager.rightHandSkeleton;
                if(targetHandData.Bones[(int)targetBoneID] != null)
                    targetBone = targetHandData.Bones[(int)targetBoneID];
                break;
        }
    }
    

    public void ChangeTint(float alpha)
    {
        Color spriteColor = new Color(1,1,1,alpha);
        sprite.color = spriteColor;
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