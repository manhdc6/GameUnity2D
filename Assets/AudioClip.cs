using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audioSource;    // Reference to the AudioSource
    public AudioClip[] audioClips;     // Array of audio clips to play
    private int currentClipIndex = 0;  // Track the current clip index

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        PlayNextClip();  // Start by playing the first clip
    }

    void Update()
    {
        // Check if the audio source is not playing and move to the next clip
        if (!audioSource.isPlaying)
        {
            PlayNextClip();
        }
    }

    void PlayNextClip()
    {
        if (audioClips.Length == 0) return;  // If no clips are assigned, do nothing

        // Play the current clip
        audioSource.clip = audioClips[currentClipIndex];
        audioSource.Play();

        // Move to the next clip, loop back to the first clip if at the end
        currentClipIndex = (currentClipIndex + 1) % audioClips.Length;
    }
}
