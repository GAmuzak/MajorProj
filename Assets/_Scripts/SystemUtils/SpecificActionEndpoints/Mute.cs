using System;
using UnityEngine;

public class Mute : MonoBehaviour, IInteractable
{
    public static event Action<bool> onMuteToggle; 

    [SerializeField] private bool state=false;
    
    private Volume volume;
    private bool canMute=true;
    
    private void Awake()
    {
        volume = transform.parent.GetComponent<Volume>();
    }

    public void Interact()
    {
        if (!canMute) return;
        state = !state;
        volume.ToggleMute(state);
        onMuteToggle?.Invoke(state);
        canMute = false;
    }

    public void Complete()
    {
        canMute = true;
    }
}