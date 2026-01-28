using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayer : MonoBehaviour
{
public GameObject player;
public GameObject builder;

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
            builder.SetActive(true);
            selector.SetActive(true);
            SetButtonsActive(true);
        }
        else{
            player.SetActive(true);
            playerCam.SetActive(true);
            builder.SetActive(false);
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
