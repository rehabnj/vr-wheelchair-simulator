using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WheelchairSpawner : MonoBehaviour
{

    public Camera mainCam;

    public GameObject whellChairGO;
    public Transform whellChairPos;
    public TMP_Text warningTxtInspawner;
    //private variables
    GameObject spawnedWhellChair;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Works");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void disableMainCam()
    {
        mainCam.gameObject.SetActive(false);
    }

    public void spawnWhellChair()
    {
        spawnedWhellChair = Instantiate(whellChairGO, whellChairPos.position, Quaternion.identity);
        CollisionDetection ct = spawnedWhellChair.GetComponent<CollisionDetection>();
       // ct.warningTxt = warningTxtInspawner;
    }
}
