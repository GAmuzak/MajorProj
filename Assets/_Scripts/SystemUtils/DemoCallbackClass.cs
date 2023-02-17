using System;
using UnityEngine;

public class DemoCallbackClass : MonoBehaviour
{
    private void FixedUpdate()
    {
        
        //For Continuous Actions
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            ServiceWrapper.Instance.ExecuteServiceUtil(SystemAction.BrightnessUp);
        }

        else if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            ServiceWrapper.Instance.ExecuteServiceUtil(SystemAction.BrightnessDown);
        }
        
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {
            ServiceWrapper.Instance.ExecuteServiceUtil(SystemAction.VolumeUp);
        }

        else if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            ServiceWrapper.Instance.ExecuteServiceUtil(SystemAction.VolumeDown);
        }

        
        //For One-Time Actions
        if (OVRInput.Get(OVRInput.Button.One))
        {
            ServiceWrapper.Instance.ExecuteServiceUtil(SystemAction.Mute);
        }
        else if (OVRInput.GetUp(OVRInput.Button.One))
        {
            ServiceWrapper.Instance.EndServiceUtil(SystemAction.Mute);
        }
    }
}
