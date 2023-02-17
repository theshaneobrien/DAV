using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 1;
    
    
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

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raycastDistance, Color.red);
        
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hitObject, raycastDistance))
        {
            if (hitObject.collider.CompareTag("RayCastInteractable"))
            {
                InteractableObject theObjectWeHit = hitObject.collider.GetComponent<InteractableObject>();
                
                InteractWithDetectedObject(theObjectWeHit);
                GameStateManager.Instance.GetUiManager().SetContextText("Press E to " + theObjectWeHit.GetVerb() + " the " + theObjectWeHit.GetName());
            }
        }
        else
        {
            GameStateManager.Instance.GetUiManager().SetContextText("");
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
