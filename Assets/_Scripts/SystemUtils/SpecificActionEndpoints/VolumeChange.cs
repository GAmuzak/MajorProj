using System;
using UnityEngine;

public class VolumeChange : MonoBehaviour, IInteractable
{
    [SerializeField] private IncreaseOrDecrease state;
    
    private Volume volume;
    private int upOrDown;

    private void Awake()
    {
        upOrDown = state == IncreaseOrDecrease.Increase ? 1 : -1;
        volume = transform.parent.GetComponent<Volume>();
    }

    public void Interact()
    {
        volume.Adjust(volume.CurrentVal+upOrDown*volume.Sensitivity);
    }

    public void Complete()
    {
        //Not Relevant
    }
}
