using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class Brightness : MonoBehaviour, IInteractable
{
    [SerializeField] private PostProcessProfile brightness;
    // [SerializeField] private PostProcessLayer layer;
    

    private AutoExposure exposure;
    private void Awake()
    {
        brightness.TryGetSettings(out exposure);
    }

    public void Interact(float val)
    {
        AdjustBrightness(val);
    }

    private void AdjustBrightness(float val)
    {
        exposure.keyValue.value = val > 0 ? val : 0.02f;
    }
    
    /*
     * UNUSED OVERLOADED INTERFACE FUNCTIONS BELOW
     */
    
    public void Interact()
    {
        throw new Exception("ERROR: Incorrect Overload Called: " + gameObject.name + "; Brightness;");
    }

    public void Interact(bool state)
    {
        throw new Exception("ERROR: Incorrect Overload Called: " + gameObject.name + "; Brightness;");
    }

    public void Interact(int val)
    {
        throw new Exception("ERROR: Incorrect Overload Called: " + gameObject.name + "; Brightness;");
    }
}
