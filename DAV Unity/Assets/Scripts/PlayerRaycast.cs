using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectViaRayCast();
    }

    private void DetectViaRayCast()
    {
        RaycastHit hitObject;

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100, Color.red);
        
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hitObject, 100))
        {
            if (hitObject.collider.CompareTag("RayCastInteractable"))
            {
                InteractWithDetectedObject(hitObject.collider.GetComponent<InteractableObject>());
            }
        }
    }

    private void InteractWithDetectedObject(InteractableObject objectWeDetected)
    {
        if (Input.GetButtonDown("Interact"))
        {
            objectWeDetected.InteractWithObject();
        }
    }
}
