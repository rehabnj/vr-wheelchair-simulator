using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptionsController : MonoBehaviour
{
    public Toggle toggle;
    private const string TOGGLE_PREF_KEY = "ToggleState";

    void Start()
    {
        if (PlayerPrefs.HasKey(TOGGLE_PREF_KEY))
        {
            toggle.isOn = PlayerPrefs.GetInt(TOGGLE_PREF_KEY) == 1;
        }
        else
        {
            toggle.isOn = true;
            SaveState(true); 
        }
    }

    void OnEnable()
    {
        toggle.onValueChanged.AddListener(SaveState);
    }

    void OnDisable()
    {
        toggle.onValueChanged.RemoveListener(SaveState);
    }

    void SaveState(bool isOn)
    {
        PlayerPrefs.SetInt(TOGGLE_PREF_KEY, isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}
