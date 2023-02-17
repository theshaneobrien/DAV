using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    
    private void Start()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
    }
    
    private void OnTriggerEnter(Collider thingInsideTrigger)
    {
        if (thingInsideTrigger.tag == "Player")
        {
            Debug.Log("We won");
            GameStateManager.Instance.SetPlayerWon();
        }
    }
}
