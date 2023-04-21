using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipSong : InteractableMonoBehaviour
{
    [SerializeField] private IncreaseOrDecrease state;
    
    private MusicPlayerManager musicPlayer;
    private AudioSource audioSource;
    private Window musicPlayerWindow;
    private bool isPlaying;
    private int upOrDown;
    void Start()
    {
        musicPlayer = GetComponent<MusicPlayerManager>();
        musicPlayerWindow = musicPlayer.musicPlayerWindow;
        audioSource = GetComponent<AudioSource>();
        upOrDown = state switch
        {
            IncreaseOrDecrease.Increase => 1,
            IncreaseOrDecrease.Decrease => -1,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public override void Interact()
    {
        if(!musicPlayerWindow.isOpen) return;
        musicPlayer.currentTrackIndex += upOrDown;
        musicPlayer.UpdateTrack();

    }
    
    public override void Complete()
    {
        
    }
}
