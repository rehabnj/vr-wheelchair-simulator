using UnityEngine;
using UnityEngine.UI;

public class HidePanelOnClick : MonoBehaviour
{
    public GameObject uiPanel; // Reference to the UI panel
    public Button yourButton;  // Reference to the button

    void Start()
    {
        // Ensure the UI panel is initially active (or set its state as needed)
        if (uiPanel == null)
        {
            Debug.LogError("UI Panel reference is missing.");
        }

        // Add a listener to the button to call the HidePanel method when clicked
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(HidePanel);
        }
        else
        {
            Debug.LogError("Button reference is missing.");
        }
    }

    void HidePanel()
    {
        // Deactivate the UI panel
        if (uiPanel != null)
        {
            uiPanel.SetActive(false);
        }
    }
}

