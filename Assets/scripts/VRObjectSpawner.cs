using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VRObjectSpawner : MonoBehaviour
{

    
    public LayerMask desiredLayer;
    public InputActionReference gripPressed;
    public GameObject objectToSpawn;
    public Transform origin;
         
  [SerializeField]  public XRController controller;
    private  GameObject spawnedObject;
    
    bool objectPlaced = false;

    [Header("game objects to spawn")]
    public GameObject Chair;

    public GameObject shelf;

    public GameObject table00;
    public GameObject printer;
    public GameObject table01;
    // Start is called before the first frame update
    void Start()
    {
        gripPressed.action.Enable();
        controller = GetComponent<XRController>();
        if(controller == null) print("couldn't find XRController    ");
    }

    // Update is called once per frame
    void Update()
    {
        if (!objectPlaced && spawnedObject != null)
        {
            Ray ray = new Ray(origin.transform.position, origin.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, desiredLayer))
            {
                spawnedObject.transform.position = hit.point;
            }

            bool isGripPressed = gripPressed.action.ReadValue<float>()>0.5f;
            
            print(isGripPressed);
            if (isGripPressed)
            {
                objectPlaced = true;
            }
        }
    }
    public void SpawnObject(string objectToSpawn)
    {
        spawnedObject = null;
        objectPlaced = false;
     spawnedObject=   objectToSpawn switch
        {
            "Chair" => Instantiate(Chair),
            "shelf" => Instantiate(shelf),
            "table00" => Instantiate(table00),
            "printer" => Instantiate(printer),
            "table01" => Instantiate(table01)
        };
        
    }
}
