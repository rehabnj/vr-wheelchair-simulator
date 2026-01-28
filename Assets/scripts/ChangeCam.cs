using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCam : MonoBehaviour
{
   public GameObject firstPerson;


  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void whenButtonClicked(){
        if (firstPerson.activeInHierarchy == true){
            firstPerson.SetActive(false);
    
   
        }
        else{
            firstPerson.SetActive(true);

        
        }
        
    }
     
    
}
