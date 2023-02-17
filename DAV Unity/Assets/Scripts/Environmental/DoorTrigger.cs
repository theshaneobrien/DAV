using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private DoorBehaviour door;

    private void Start()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
    }
    
    private void OnTriggerEnter(Collider thingInsideTrigger)
    {
        if (thingInsideTrigger.tag == "Player")
        {
            GameStateManager.Instance.GetUiManager().SetContextText("Press E to open the Door");
            GameStateManager.Instance.SetCurrentContextInteractable(true, door);
        }
    }

    private void OnTriggerStay(Collider thingInsideTrigger)
    {
        if (thingInsideTrigger.tag == "Player")
        {
            
        }
    }

    private void OnTriggerExit(Collider thingInsideTrigger)
    {
        if (thingInsideTrigger.tag == "Player")
        {
            GameStateManager.Instance.GetUiManager().HideText();
            GameStateManager.Instance.SetCurrentContextInteractable(false, null);
        }
    }
}
