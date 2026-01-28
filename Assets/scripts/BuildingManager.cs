using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject pendingObject;

    [SerializeField] private Material[] materials; // Ensure there are at least 3 materials
    public float rotateAmount;

    private Vector3 pos;
    private RaycastHit hit;

    public bool canPlace = false;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private float rotationSpeed = 1.0f; // Default rotation speed

    private Material originalMaterial;

    // Update is called once per frame
    void Update()
    {
        if (pendingObject != null)
        {
            pendingObject.transform.position = pos;
            if (Input.GetMouseButtonDown(0) && canPlace)
            {
                PlaceObject();
            }
            if (Input.GetKey(KeyCode.R))
            {
                RotateObject();
            }
            UpdateMaterials();
        }
    }

    public void PlaceObject()
    {
        if (materials.Length > 2 && pendingObject != null)
        {
            pendingObject.GetComponent<MeshRenderer>().material = originalMaterial; // Return to original material
            pendingObject = null;
        }
        else
        {
            Debug.LogError("Materials array does not have enough elements or pendingObject is null.");
        }
    }

    public void RotateObject()
    {
        pendingObject.transform.Rotate(Vector3.up, rotateAmount);
    }

    void UpdateMaterials()
    {
        if (pendingObject != null)
        {
            if (canPlace)
            {
                if (materials.Length > 0)
                {
                    pendingObject.GetComponent<MeshRenderer>().material = materials[0]; // Can place material
                }
                else
                {
                    Debug.LogError("Materials array does not have enough elements.");
                }
            }
            else
            {
                if (materials.Length > 1)
                {
                    pendingObject.GetComponent<MeshRenderer>().material = materials[1]; // Cannot place material
                }
                else
                {
                    Debug.LogError("Materials array does not have enough elements.");
                }
            }
        }
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            pos = hit.point;
        }
    }

    public void SelectObject(int index)
    {
        if (index >= 0 && index < objects.Length)
        {
            pendingObject = Instantiate(objects[index], pos, transform.rotation);
            originalMaterial = pendingObject.GetComponent<MeshRenderer>().material; // Store the original material
        }
        else
        {
            Debug.LogError("Index out of range when selecting object.");
        }
    }
}
