using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    public static event Action<ScenarioController, GameObject> OnComponentClicked;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera through the mouse pointer
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                GameObject objectHit = hit.transform.gameObject;
                Debug.Log("Raycast hit: " + objectHit.name);

                OnComponentClicked(objectHit.GetComponent<InteractableObject>().scenario, 
                                    objectHit.GetComponent<InteractableObject>().componentToShow);
            }

        }
    }
}
