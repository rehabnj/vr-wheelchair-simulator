using UnityEngine;
using UnityEngine.SceneManagement;  // Needed to handle scene management
using UnityEngine.UI;              // Needed to handle UI elements

public class SceneChanger : MonoBehaviour
{
    public string sceneName;  // Name of the scene to load

    private void Start()
    {
        // Get the Button component on this GameObject
        Button button = GetComponent<Button>();
        if (button != null)
        {
            // Add a listener to the button to call the ChangeScene method when clicked
            button.onClick.AddListener(ChangeScene);
        }
    }

    // Method to change the scene
    void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

