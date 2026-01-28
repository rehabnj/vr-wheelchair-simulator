using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnGO : MonoBehaviour
{

    public LayerMask _desiredLayer;

    public GameObject chairGO;
    public Camera mainCamera;
    GameObject spawnedChair;

    bool _isObjectPlaced=false;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray rayFromMousePosition = mainCamera.ScreenPointToRay(Input.mousePosition);
  Debug.DrawRay(rayFromMousePosition.origin,
            rayFromMousePosition.origin+mainCamera.transform.forward*100f,Color.red);

        RaycastHit hitInfo;

        if(spawnedChair!=null&& _isObjectPlaced!=true )
        {
       if(Physics.Raycast(rayFromMousePosition,out hitInfo,100,_desiredLayer))
       {
            Debug.Log("ray hit"+hitInfo.collider.gameObject.name);
            Debug.DrawRay(rayFromMousePosition.origin,
            rayFromMousePosition.origin+mainCamera.transform.forward*100f,Color.red);

        spawnedChair.transform.position=hitInfo.point;

                float wheelDelta = Input.GetAxis("Mouse ScrollWheel");

                if (wheelDelta > 0)
                {
                     spawnedChair.transform.Rotate(0, wheelDelta*50,0);
                }
                else if (wheelDelta < 0)
                {
                    spawnedChair.transform.Rotate(0, wheelDelta * 50, 0);
                }

                if(Input.GetMouseButton(0))
                {
                    _isObjectPlaced=true;
                }
            }
        }
    
    }

    public void DoSpawnChair()
    {
       
        spawnedChair = Instantiate(chairGO);

        _isObjectPlaced = false;



    }


}
