using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideo : InteractableMonoBehaviour
{

    private VideoManager videoManager;
    private Window window;
    private bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {
        videoManager = GetComponentInChildren<VideoManager>();
        window = GetComponent<Window>();
    }
    
    public override void Interact()
    {
        if(!window.isOpen) return;
        if (isPlaying)
        {
            videoManager.VideoPlayerPause();
            isPlaying = false;
        }
        else
        {
            videoManager.VideoPlayerPlay();
            isPlaying = true;
        }
    }

    public override void Complete()
    {
        
    }
}
