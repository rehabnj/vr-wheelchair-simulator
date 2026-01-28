using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class UIHeartPresenter : MonoBehaviour
{

  public List<GameObject> hearts = new List<GameObject>();
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject heart in hearts)
        {
            heart.SetActive(false);
        }

        int liveHearts = GameManager.Instance.health;

        for (int i = 0; i < liveHearts; i++)
        {
            hearts[i].SetActive(true);
        }
        if(gameOverPanel != null&& liveHearts==0)
        {
            gameOverPanel.SetActive(true);
        }

    }
}
