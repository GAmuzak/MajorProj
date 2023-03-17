using System;
using UnityEngine;

public class VolumeChange : InteractableMonoBehaviour
{
    public static event Action<float> OnVolumeChange;
    
    [SerializeField] private IncreaseOrDecrease state;
    
    private Volume volume;
    private int upOrDown;
    private CanvasGroup volumeCanvasGroup;

    private void Awake()
    {
        volume = transform.parent.GetComponent<Volume>();
        volumeCanvasGroup = volume.volumeCanvasGroup;
        upOrDown = state switch
        {
            IncreaseOrDecrease.Increase => 1,
            IncreaseOrDecrease.Decrease => -1,
            IncreaseOrDecrease.Neutral => 0,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public override void Interact()
    {
        volumeCanvasGroup.alpha = 1f;
        float newVal = volume.CurrentVal+upOrDown*volume.Sensitivity;
        volume.Adjust(newVal);
        OnVolumeChange?.Invoke(newVal);
    }

    public override void Complete()
    {
        volumeCanvasGroup.alpha = 0f;
    }
}
