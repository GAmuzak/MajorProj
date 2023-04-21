using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayerManager : MonoBehaviour
{
    [SerializeField] private TrackThumbnailDict musicTracks;
    [SerializeField] private Image thumbnail;
    
    public AudioSource audioSource;
    public Window musicPlayerWindow;

    private List<AudioClip> trackList;
    public int currentTrackIndex;
    // Start is called before the first frame update
    void Awake()
    {
        trackList = musicTracks.Keys.ToList();
        musicPlayerWindow = GetComponent<Window>();
        currentTrackIndex = 0;
        UpdateTrack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateTrack()
    {
        if (currentTrackIndex < 0 || currentTrackIndex > trackList.Count - 1) currentTrackIndex = 0;
        audioSource.clip = trackList[currentTrackIndex];
        thumbnail.sprite = musicTracks[trackList[currentTrackIndex]];
        Debug.Log("UpdatingTrack");
    }
}


[Serializable]
public class TrackThumbnailDict : SerializableDictionary<AudioClip, Sprite> {}