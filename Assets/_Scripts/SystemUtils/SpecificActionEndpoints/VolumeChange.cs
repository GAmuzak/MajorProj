using System;
using UnityEngine;

public class VolumeChange : InteractableMonoBehaviour
{
    public static event Action<float> OnVolumeChange;
    
    [SerializeField] private IncreaseOrDecrease state;
    
    private Volume volume;
    private int upOrDown;

    private void Awake()
    {
        upOrDown = state == IncreaseOrDecrease.Increase ? 1 : -1;
        volume = transform.parent.GetComponent<Volume>();
    }

    public override void Interact()
    {
        float newVal = volume.CurrentVal+upOrDown*volume.Sensitivity;
        volume.Adjust(newVal);
        OnVolumeChange?.Invoke(newVal);
    }

    public override void Complete()
    {
        //Not Relevant
    }
}
