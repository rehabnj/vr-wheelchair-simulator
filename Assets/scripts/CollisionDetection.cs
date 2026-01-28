using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    public AudioSource audioSource;
  //  public TMP_Text warningTxt;
    // Start is called before the first frame update
    void Start()
    {
       // warningTxt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {

        if(other.gameObject.tag == "Furniture")
        {

            print(other.gameObject.name + " collided with us");
          //  warningTxt.enabled = true;
           // warningTxt.text = other.gameObject.name + " Thuds";
            Invoke("HideText", 3f);
            if (!audioSource.isPlaying)
            {  
                audioSource.Play();
            }
            GameManager.Instance.DecreaseHealth();
        }

    }

    void HideText()
    {
       // warningTxt.enabled = false;
    }
}
