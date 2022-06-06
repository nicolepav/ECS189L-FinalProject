using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/*
 * Based on SoundManager code from ECS 189L Exercises.
 *
 * Adapted from "Indroduction to AUDIO in Unity" by Brackeys:
 * https://www.youtube.com/watch?v=6OT43pvUyfY
 */

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField]
    private AudioMixerGroup musicMixerGroup;

    [SerializeField]
    private AudioMixerGroup sfxMixerGroup;

    [SerializeField]
    private List<SoundClip> musicTracks;

    [SerializeField]
    private List<SoundClip> sfxClips;

    private SoundClip trackPlaying;
    private SoundClip trackFading;
    private SoundClip sfxPlaying;


    void Awake()
    {
        Instance = this;

        foreach (var track in this.musicTracks)
        {
            track.audioSource = this.gameObject.AddComponent<AudioSource>();
            track.audioSource.clip = track.clip;
            track.audioSource.volume = track.volume;
            track.audioSource.pitch = track.pitch;
            track.audioSource.loop = track.loop;
            track.audioSource.outputAudioMixerGroup = this.musicMixerGroup;
        }

        foreach (var clip in this.sfxClips)
        {
            clip.audioSource = this.gameObject.AddComponent<AudioSource>();
            clip.audioSource.clip = clip.clip;
            clip.audioSource.volume = clip.volume;
            clip.audioSource.pitch = clip.pitch;
            clip.audioSource.loop = clip.loop;
            clip.audioSource.outputAudioMixerGroup = this.sfxMixerGroup;
        }

        // Initial music track that plays on game start up.
        this.PlayMusicTrack("Title");
        
        DontDestroyOnLoad(this);
    }

    // To play music track from a script, use:
    // SoundManager.Instance.PlayMusicTrack("[Name of Audio Asset]");
    public void PlayMusicTrack(string title)
    {
        var track = this.musicTracks.Find(track => track.title == title);

        if (this.trackPlaying == track)
        {
            // Do not duplicate same music track.
            return;
        }

        if(null == track) 
        {
            Debug.Log("Sound track not found: " + title);
            return;
        }
        
        track.audioSource.Play();

        if(null != this.trackPlaying) {
            this.trackPlaying.audioSource.Stop();
        }   

        this.trackPlaying = track;

        Debug.Log("now playing " + title);
    }

    // To play sound effect from a script, use:
    // SoundManager.Instance.PlaySoundEffect("[Name of Audio Asset]");
    public void PlaySoundEffect(string title)
    {
        var track = this.sfxClips.Find(track => track.title == title);

        if(null == track) 
        {
            Debug.Log("Sound track not found: " + title);
            return;
        }

        track.audioSource.Play();

        Debug.Log("sound effect! " + title);
    }

    public void StopSoundEffect(string title)
    {
        var track = this.sfxClips.Find(track => track.title == title);

        if(null == track)
        {
            Debug.Log("Sound track not found: " + title);
            return;
        }

        track.audioSource.Stop();
    }
}
