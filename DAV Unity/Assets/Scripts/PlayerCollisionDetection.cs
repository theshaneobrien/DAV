using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{

    private void Start()
    {
    }
    
    private void OnCollisionEnter(Collision thingWeHit)
    {
        
        //Play Sounds of thing hitting other thing
    }

    private void OnCollisionStay(Collision thingWeHit)
    {
        // Draw all contact points and normals
        foreach (ContactPoint contact in thingWeHit.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.black);
        }
    }

    private void OnCollisionExit(Collision thingWeHit)
    {
    }
}
