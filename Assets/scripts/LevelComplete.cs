using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
     public GameObject uiPanel;
    // Start is called before the first frame update
    void Start()
    {
         if (uiPanel != null)
        {
            uiPanel.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (uiPanel != null)
        {
            uiPanel.SetActive(true);
        }
    }

    }

   

