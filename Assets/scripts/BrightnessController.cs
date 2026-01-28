using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BrightnessController : MonoBehaviour
{
    [SerializeField] private Slider brightnessSlider;
    [SerializeField] private Image overlay;

    private const string BrightnessPrefKey = "BrightnessValue";

    void Start()
    {
        // Load the saved brightness value or use a default value if not found
        float savedBrightness = PlayerPrefs.GetFloat(BrightnessPrefKey, 1f);
        brightnessSlider.value = savedBrightness;

        // Add a listener to save the brightness value when it changes
        brightnessSlider.onValueChanged.AddListener(OnBrightnessChanged);

        // Apply the initial brightness setting
        DarkOverlay();
    }

    void Update()
    {
        // Continuously apply the brightness setting (if needed)
        DarkOverlay();
    }

    private void DarkOverlay()
    {
        var tempColor = overlay.color;
        tempColor.a = brightnessSlider.value;
        overlay.color = tempColor;
    }

    private void OnBrightnessChanged(float value)
    {
        // Save the brightness value to PlayerPrefs
        PlayerPrefs.SetFloat(BrightnessPrefKey, value);
        PlayerPrefs.Save();
    }
}
