using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCharacterController : MonoBehaviour
{

    [SerializeField] private float walkSpeed = 2.0f;

    private float forward = 0.0f;
    private float right = 0.0f;

    private Rigidbody playerRb;
    
    // Start is called before the first frame update
    private void Start()
    {
        playerRb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    { 
        GetInputs();
    }

    private void GetInputs()
    {
        forward = Input.GetAxis("Vertical");
        right = Input.GetAxis("Horizontal");
    }

    private void MoveCharacter()
    {
        
    }
}
