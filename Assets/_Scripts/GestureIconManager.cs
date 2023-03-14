using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureIconManager : MonoBehaviour
{

    [SerializeField] public GestureIconDict FunctionToIconManager;
    [HideInInspector] public OVRHand leftHand;
    [HideInInspector] public OVRSkeleton leftHandSkeleton;
    [HideInInspector] public OVRHand rightHand;
    [HideInInspector] public OVRSkeleton rightHandSkeleton;
    
    
    private GestureIcon[] gestureIconList;
    void Start()
    {
        OVRHand[] hands = FindObjectsOfType<OVRHand>();
        foreach (OVRHand hand in hands)
        {
            OVRSkeleton skeleton = hand.gameObject.GetComponent<OVRSkeleton>();
            OVRSkeleton.SkeletonType handType = skeleton.GetSkeletonType();
            switch (handType)
            {
                case OVRSkeleton.SkeletonType.HandLeft:
                    leftHand = hand;
                    leftHandSkeleton = skeleton;
                    break;
                case OVRSkeleton.SkeletonType.HandRight:
                    rightHand = hand;
                    rightHandSkeleton = skeleton;
                    break;
            }
        }

        gestureIconList = GetComponentsInChildren<GestureIcon>();
    }

    public void SetIconVisibility(float alpha)
    {
        foreach (GestureIcon icon in gestureIconList)
        {
            icon.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public class GestureIconDict : SerializableDictionary<HandGestureIdentifier, GestureIcon> {}


