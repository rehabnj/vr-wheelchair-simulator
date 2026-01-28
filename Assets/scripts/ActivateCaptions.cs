using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCaptions : MonoBehaviour
{
   public GameObject panel;

    // Ensure the panel is hidden at the start
    void Start()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    // Detect the trigger enter event
    void OnTriggerEnter(Collider other)
    {
            if (panel != null)
            {
                panel.SetActive(true);
            }
        }
    }

