using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioSource> audioSources; // List of AudioSource components
    private const string TOGGLE_PREF_KEY = "AudioToggleState"; // Key used to retrieve the toggle state

    void Start()
    {
        // Check the saved state
        bool isAudioEnabled = PlayerPrefs.GetInt(TOGGLE_PREF_KEY, 0) == 1;

        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.enabled = isAudioEnabled;

            if (isAudioEnabled)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }
        }
    }
}
