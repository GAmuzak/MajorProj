using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : InteractableMonoBehaviour
{
    [SerializeField] private Image playStatusImage;
    [SerializeField] private Sprite playImage;
    [SerializeField] private Sprite pauseImage;
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
            playStatusImage.sprite = pauseImage;
        }
        else
        {
            PlayMusic();
            isPlaying = true;
            playStatusImage.sprite = playImage;
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
