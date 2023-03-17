using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : InteractableMonoBehaviour
{
    [SerializeField] private Image playImage;
    private MusicPlayerManager musicPlayer;
    private AudioSource audioSource;
    private Window musicPlayerWindow;
    private bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = GetComponent<MusicPlayerManager>();
        musicPlayerWindow = musicPlayer.musicPlayerWindow;
        audioSource = GetComponent<AudioSource>();
    }
    
    public override void Interact()
    {
        if(!musicPlayerWindow.isOpen) return;
        if (isPlaying)
        {
            PauseMusic();
            isPlaying = false;
        }
        else
        {
            PlayMusic();
            isPlaying = true;
        }
    }

    private void PlayMusic()
    {
        audioSource.Play();
    }

    private void PauseMusic()
    {
        audioSource.Pause();
    }

    public override void Complete()
    {
        
    }


}
