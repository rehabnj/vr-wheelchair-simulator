using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptionsManager : MonoBehaviour
{
   private const string TOGGLE_PREF_KEY = "ToggleState";

    void Start()
    {
        // Load the toggle state
        bool isToggleOn = PlayerPrefs.GetInt(TOGGLE_PREF_KEY, 0) == 1;

        // Enable or disable the GameObject based on the toggle state
        gameObject.SetActive(isToggleOn);
    }
}
