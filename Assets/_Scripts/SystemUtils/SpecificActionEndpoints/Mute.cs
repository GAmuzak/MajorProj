using System;
using OculusSampleFramework;
using UnityEngine;

public class Mute : InteractableMonoBehaviour
{
    public static event Action<bool> onMuteToggle; 

    [SerializeField] private bool state=false;
    
    private Volume volume;
    private bool canMute=true;
    
    private void Awake()
    {
        volume = transform.parent.GetComponent<Volume>();
    }

    public override void Interact()
    {
        if (!canMute) return;
        volume.ToggleMute(!state);
        state = !state;
        onMuteToggle?.Invoke(state);
        canMute = false;
    }

    public override void Complete()
    {
        canMute = true;
    }
}