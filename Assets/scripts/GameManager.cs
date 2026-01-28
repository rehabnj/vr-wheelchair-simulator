using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GameManager : MonoBehaviour
{

  static GameManager instance;
  public  static GameManager Instance
    {
        get
        {
            if(instance == null)
                instance= FindObjectOfType<GameManager>();
            return instance;
        }
    }


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }



    public int health = 3;

    public void DecreaseHealth()
    {
        if (health > 0)
        {
            health--;
        }

        // game over check
        if (health == 0)
        {
            // Game Over Logic
            Debug.Log("Game Over");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGame()
    {
      
    }
}
