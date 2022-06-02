using UnityEngine.Audio;
using UnityEngine;

/*
 * Based on SoundManager code from ECS 189L Exercises.
 *
 * Adapted from "Indroduction to AUDIO in Unity" by Brackeys:
 * https://www.youtube.com/watch?v=6OT43pvUyfY
 */

[System.Serializable]
public class SoundClip 
{
    public AudioClip clip;

    [HideInInspector]
    public AudioSource audioSource;

    public string title;

    [Range(0f, 1f)]
    public float volume = 1.0f;
    
    [Range(0.1f, 3f)]
    public float pitch = 1.0f;
    
    public bool loop = true;
}
