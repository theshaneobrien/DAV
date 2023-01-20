using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    private Vector3 doorStartingPosition = new Vector3();

    [SerializeField] private float distanceToOpen;
    [SerializeField] private Animator doorAnimator;

    private void Start()
    {
        doorStartingPosition = this.transform.position;
    }
    
    public void OpenDoor()
    {
        Debug.Log("Door is open! Promise!");

        this.transform.position = new Vector3(doorStartingPosition.x + distanceToOpen, doorStartingPosition.y, doorStartingPosition.z);
        doorAnimator.SetTrigger("OpenTheDoor");
    }
}
