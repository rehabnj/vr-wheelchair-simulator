using UnityEngine;
using UnityEngine.UI;

public class ShowPanelOnClick : MonoBehaviour
{
    public GameObject uiPanel; // Reference to the UI panel
    public Button yourButton;  // Reference to the button

    void Start()
    {
        // Ensure the UI panel is initially inactive
        if (uiPanel != null)
        {
            uiPanel.SetActive(false);
        }

        // Add a listener to the button to call the ShowPanel method when clicked
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(ShowPanel);
        }
    }

    void ShowPanel()
    {
        // Activate the UI panel
        if (uiPanel != null)
        {
            uiPanel.SetActive(true);
        }
    }
}

