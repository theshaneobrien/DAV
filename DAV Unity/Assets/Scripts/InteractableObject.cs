using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private string objectName = "puzzlePiece";

    [SerializeField] private float yRotation;
    // Start is called before the first frame update
    void Start()
    {
        yRotation = transform.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetName()
    {
        return objectName;
    }

    public void InteractWithObject()
    {
        yRotation = yRotation + 15;

        if (yRotation >= 360)
        {
            yRotation = 0;
        }

        this.transform.rotation = Quaternion.Euler(0.0f, yRotation, 0.0f);
    }
}
