using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private string objectName;
    [SerializeField] private string interactionVerb;

    [SerializeField] private float yRotation;
    // Start is called before the first frame update
    void Start()
    {
        yRotation = transform.rotation.eulerAngles.y;
    }

    public string GetName()
    {
        return objectName;
    }

    public string GetVerb()
    {
        return interactionVerb;
    }

    public void InteractWithObject()
    {
        if (interactionVerb == "Rotate")
        {
            RotateObject();
        }

        if (interactionVerb == "Pickup")
        {
            PickupObject();
        }
    }

    private void RotateObject()
    {
        yRotation = yRotation + 15;

        if (yRotation >= 360)
        {
            yRotation = 0;
        }

        this.transform.rotation = Quaternion.Euler(0.0f, yRotation, 0.0f);
    }

    private void PickupObject()
    {
        GameStateManager.Instance.AddToInventory(objectName);
        
        Destroy(this.gameObject);
    }
}
