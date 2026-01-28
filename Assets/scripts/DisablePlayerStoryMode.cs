using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayerStoryMode : MonoBehaviour
{
public GameObject player;

public GameObject selector;

public GameObject playerCam;


  public GameObject[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void whenButtonClicked(){
        if (player.activeInHierarchy == true){
            player.SetActive(false);
            playerCam.SetActive(false);
            selector.SetActive(true);
            SetButtonsActive(true);
        }
        else{
            player.SetActive(true);
            playerCam.SetActive(true);
            selector.SetActive(false);
            SetButtonsActive(false);
        }
        
    }
      private void SetButtonsActive(bool isActive)
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(isActive);
        }
    }
    
}

