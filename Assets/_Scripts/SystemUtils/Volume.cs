using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour, IInteractable
{
    private float prevVal;
    private HandGesture inputTigger;
    
    public void Interact(float val)
    {
        AdjustVolume(val);
    }

    public void Interact(bool state)
    {
        ToggleMute(state);
    }

    private void AdjustVolume(float val)
    {
        AudioListener.volume = val;
    }

    private void ToggleMute(bool state)
    {
        if (state)
        {
            prevVal = AudioListener.volume;
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = prevVal;
        }
    }

    /*
     * UNUSED OVERLOADED INTERFACE FUNCTIONS BELOW
     */


    public void Interact()
    {
        throw new Exception("ERROR: Incorrect Overload Called: " + gameObject.name + "; Brightness;");
    }

    public void Interact(int val)
    {
        throw new Exception("ERROR: Incorrect Overload Called: " + gameObject.name + "; Brightness;");
    }
}
