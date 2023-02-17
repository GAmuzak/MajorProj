using System;
using UnityEngine;

public class DemoCallbackClass : MonoBehaviour
{
    private void FixedUpdate()
    {
        
        //For Continuous Actions
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            ServiceWrapper.Instance.ExecuteServiceUtil(SystemAction.BrightnessUp);
        }

        else if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            ServiceWrapper.Instance.ExecuteServiceUtil(SystemAction.BrightnessDown);
        }
        
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            ServiceWrapper.Instance.ExecuteServiceUtil(SystemAction.VolumeUp);
        }

        else if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            ServiceWrapper.Instance.ExecuteServiceUtil(SystemAction.VolumeDown);
        }

        
        //For One-Time Actions
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            ServiceWrapper.Instance.ExecuteServiceUtil(SystemAction.Mute);
        }
        else if (OVRInput.GetUp(OVRInput.Button.One))
        {
            ServiceWrapper.Instance.EndServiceUtil(SystemAction.Mute);
        }
    }
}
