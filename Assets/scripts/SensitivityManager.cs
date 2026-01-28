using UnityEngine;
using UnityEngine.UI;

public class SensitivityManager : MonoBehaviour
{
    public Slider sensitivityXSlider;
    public Slider sensitivityYSlider;

    void Start()
    {
        // Load saved sensitivity values
        LoadSensitivity();
        
        // Add listeners to the sliders
        sensitivityXSlider.onValueChanged.AddListener(delegate { ChangeSensitivityX(); });
        sensitivityYSlider.onValueChanged.AddListener(delegate { ChangeSensitivityY(); });
    }

    public void ChangeSensitivityX()
    {
        // Save the new sensitivity value for X axis
        PlayerPrefs.SetFloat("sensitivityX", sensitivityXSlider.value);
    }

    public void ChangeSensitivityY()
    {
        // Save the new sensitivity value for Y axis
        PlayerPrefs.SetFloat("sensitivityY", sensitivityYSlider.value);
    }

    private void LoadSensitivity()
    {
        // Load sensitivity values from PlayerPrefs, set default values if not found
        sensitivityXSlider.value = PlayerPrefs.GetFloat("sensitivityX", 400.0f);
        sensitivityYSlider.value = PlayerPrefs.GetFloat("sensitivityY", 400.0f);
    }
}
