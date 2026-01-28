
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selection1 : MonoBehaviour
{
    public Material highlightMaterial;
    public Material selectionMaterial;

    public float rotationSpeed;

    private Material originalMaterialHighlight;
    private Material originalMaterialSelection;
    private Transform highlight;
    private Transform selection;
    private RaycastHit raycastHit;
    private bool isDragging = false;
    private Vector3 offset;

    void Update()
    {
        // Highlight
        if (highlight != null)
        {
            highlight.GetComponent<MeshRenderer>().sharedMaterial = originalMaterialHighlight;
            highlight = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {
            highlight = raycastHit.transform;
            if (highlight.CompareTag("Selectable") && highlight != selection)
            {
                if (highlight.GetComponent<MeshRenderer>().material != highlightMaterial)
                {
                    originalMaterialHighlight = highlight.GetComponent<MeshRenderer>().material;
                    highlight.GetComponent<MeshRenderer>().material = highlightMaterial;
                }
            }
            else
            {
                highlight = null;
            }
        }

        // Selection
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (highlight)
            {
                if (selection != null)
                {
                    selection.GetComponent<MeshRenderer>().material = originalMaterialSelection;
                }
                selection = raycastHit.transform;
                if (selection.GetComponent<MeshRenderer>().material != selectionMaterial)
                {
                    originalMaterialSelection = originalMaterialHighlight;
                    selection.GetComponent<MeshRenderer>().material = selectionMaterial;
                }
                isDragging = true;
                offset = selection.position - raycastHit.point;
                highlight = null;
            }
            else
            {
                if (selection)
                {
                    selection.GetComponent<MeshRenderer>().material = originalMaterialSelection;
                    selection = null;
                    isDragging = false;
                }
            }
        }

        // Dragging
        if (isDragging && selection != null && Input.GetMouseButton(0))
        {
            Ray dragRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, new Vector3(0, selection.position.y, 0)); // Plane at the object's y level
            float distance;
            if (plane.Raycast(dragRay, out distance))
            {
                Vector3 dragPoint = dragRay.GetPoint(distance) + offset;
                selection.position = new Vector3(dragPoint.x - offset.x, selection.position.y, dragPoint.z - offset.z); // Keep the y position constant
            }
        }

        // Stop dragging
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
         
          if (selection != null && Input.GetKey(KeyCode.R))
        {
            float rotation = rotationSpeed * Time.deltaTime;
            selection.Rotate(Vector3.up, rotation);
        }
    }

}
