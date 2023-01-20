using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    [SerializeField] private DoorBehaviour walkwayDoor;

    private void Start()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
    }
    
    private void OnTriggerEnter(Collider thingInsideTrigger)
    {
        Debug.Log("We have something inside the trigger");
        Debug.Log("The thing is " + thingInsideTrigger.name);
        
        walkwayDoor.OpenDoor();
    }

    private void OnTriggerStay(Collider thingInsideTrigger)
    {
        //This will constantly fire while something is in the trigger
    }

    private void OnTriggerExit(Collider thingInsideTrigger)
    {
        Debug.Log("Something left the trigger");
    }
}
