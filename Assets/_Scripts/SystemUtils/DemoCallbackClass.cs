using System;
using UnityEngine;

public class DemoCallbackClass : MonoBehaviour
{
    private void FixedUpdate()
    {
        
        //For Continuous Actions
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            ServiceWrapper.Instance.ExecuteService(SystemAction.BrightnessUp);
        }

        else if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            ServiceWrapper.Instance.ExecuteService(SystemAction.BrightnessDown);
        }
        
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {
            ServiceWrapper.Instance.ExecuteService(SystemAction.VolumeUp);
        }

        else if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            ServiceWrapper.Instance.ExecuteService(SystemAction.VolumeDown);
        }

        
        //For One-Time Actions
        if (OVRInput.Get(OVRInput.Button.One))
        {
            ServiceWrapper.Instance.ExecuteService(SystemAction.Mute);
        }
        else if (OVRInput.GetUp(OVRInput.Button.One))
        {
            ServiceWrapper.Instance.EndService(SystemAction.Mute);
        }
    }
}
