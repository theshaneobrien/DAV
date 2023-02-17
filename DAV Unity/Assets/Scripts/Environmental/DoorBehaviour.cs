using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    private Vector3 doorStartingPosition = new Vector3();

    [SerializeField] private float distanceToOpen;
    [SerializeField] private Animator doorAnimator;

    [SerializeField] private bool requiresItem = false;
    [SerializeField] private string itemRequiredToOpen;

    private void Start()
    {
        doorStartingPosition = this.transform.position;
    }
    
    public void OpenDoor()
    {
        if (requiresItem == false)
        {
            this.transform.position = new Vector3(doorStartingPosition.x + distanceToOpen, doorStartingPosition.y,
                doorStartingPosition.z);
            doorAnimator.SetTrigger("OpenTheDoor");
        }
        else
        {
            if (GameStateManager.Instance.CheckInventory(itemRequiredToOpen) == true)
            {
                this.transform.position = new Vector3(doorStartingPosition.x + distanceToOpen, doorStartingPosition.y,
                    doorStartingPosition.z);
                doorAnimator.SetTrigger("OpenTheDoor");
                GameStateManager.Instance.ConsumeItem(itemRequiredToOpen);
            }
            else
            {
                GameStateManager.Instance.GetUiManager().SetContextText("You need a key to open this door");    
            }
            
            
        }
    }
}
