using UnityEngine;

public class PlayAudioOnTriggerOnce : MonoBehaviour
{
    public AudioClip triggerClip; // The audio clip to play on trigger
    private AudioSource audioSource;
    private bool hasPlayed = false; // Flag to ensure audio is played only once

    void Start()
    {
        // Get or add an AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the audio has not been played yet
        if (!hasPlayed && triggerClip != null)
        {
            // Play the audio clip
            audioSource.PlayOneShot(triggerClip);
            // Set the flag to true to prevent replaying
            hasPlayed = true;
        }
    }
}
