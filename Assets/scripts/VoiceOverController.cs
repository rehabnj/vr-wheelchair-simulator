using UnityEngine;
using UnityEngine.UI;

public class VoiceOverController : MonoBehaviour
{
    public Toggle myToggle; 
    private const string TOGGLE_PREF_KEY = "MyToggleState"; 

    void Start()
    {
        
        if (PlayerPrefs.HasKey(TOGGLE_PREF_KEY))
        {
            bool isToggled = PlayerPrefs.GetInt(TOGGLE_PREF_KEY) == 1;
            myToggle.isOn = isToggled;
        }
        else
        {
            myToggle.isOn = false; // Default state if no saved state exists
        }

        // Add listener to handle toggle changes
        myToggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    void OnToggleValueChanged(bool isOn)
    {
        // Save the toggle state
        PlayerPrefs.SetInt(TOGGLE_PREF_KEY, isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    void OnDestroy()
    {
        // Remove listener to prevent memory leaks
        myToggle.onValueChanged.RemoveListener(OnToggleValueChanged);
    }
}

