using UnityEngine;
using UnityEngine.UI;

public class BrightnessApplier : MonoBehaviour
{
    [SerializeField] private Image overlay;

    private const string BrightnessPrefKey = "BrightnessValue";

    void Start()
    {
        // Load the saved brightness value from PlayerPrefs
        float savedBrightness = PlayerPrefs.GetFloat(BrightnessPrefKey, 1f);

        // Apply the brightness value to the overlay image
        var tempColor = overlay.color;
        tempColor.a = savedBrightness;
        overlay.color = tempColor;
    }
}

