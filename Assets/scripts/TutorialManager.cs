using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum tutorialStages { none=-1,tSgameObject, tStestButton, tSNavigation, tSHearts, tSpauseButton};

public class TutorialManager : MonoBehaviour

{
    tutorialStages myGameTS = tutorialStages.tSgameObject;
    public GameObject tSgameObjectgO; 
    public GameObject tStestButtongO; 
    public GameObject tSNavigationgO;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (myGameTS)
        {
            case tutorialStages.tSgameObject:
                tSgameObjectgO.SetActive(true);
                tStestButtongO.SetActive(false);
                tSNavigationgO.SetActive(false);
                break;

                case tutorialStages.tStestButton:
                    tSgameObjectgO.SetActive(false);
                tStestButtongO.SetActive(true);
                    tSNavigationgO.SetActive(false);
                    break;

                    case tutorialStages.tSNavigation:
                    tSgameObjectgO.SetActive(false);
                tStestButtongO.SetActive(false);
                    tSNavigationgO.SetActive(true);
                    break;


                case tutorialStages.none:
                tSgameObjectgO.SetActive(false);
                tStestButtongO.SetActive(false);
                tSNavigationgO.SetActive(false);
                break;
        }
    }

    public void increaseStage(int stage)
    {
        print (stage);
        myGameTS = (tutorialStages)stage;
    }
}
