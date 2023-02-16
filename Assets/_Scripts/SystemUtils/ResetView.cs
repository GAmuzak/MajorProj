using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetView : MonoBehaviour, IInteractable
{
    
    public void Interact()
    {
        Recenter();
    }

    private void Recenter()
    {
        // not sure if this works
        OVRManager.display.RecenterPose();
    }


    /*
     * UNUSED OVERLOADED INTERFACE FUNCTIONS BELOW
     */
    
    

    public void Interact(bool state)
    {
        throw new Exception("ERROR: Incorrect Overload Called: " + gameObject.name + "; Brightness;");
    }

    public void Interact(int val)
    {
        throw new Exception("ERROR: Incorrect Overload Called: " + gameObject.name + "; Brightness;");
    }
    
    public void Interact(float val)
    {
        throw new Exception("ERROR: Incorrect Overload Called: " + gameObject.name + "; Brightness;");
    }
}
