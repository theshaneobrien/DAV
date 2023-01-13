using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCharacterController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 2.0f;

    private float verticalInput = 0.0f;
    private float horizontalInput = 0.0f;
    private float mouseInputX = 0.0f;

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
        GetMouseInputs();
        MoveCharacter();
        RotateCharacter();
    }

    private void GetInputs()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }
    
    private void GetMouseInputs()
    {
        mouseInputX = Input.GetAxis("Mouse X");
    }

    private void MoveCharacter()
    {
        //playerRb.velocity = forward * new Vector3 (0, 0, 1) or new Vector3 (0, 0, -1)
        playerRb.velocity = this.transform.forward * (verticalInput * walkSpeed);
        
        //playerRb.velocity = right * new Vector3 (-1, 0, 1) or new Vector3 (1, 0, -1)
        playerRb.velocity = playerRb.velocity + this.transform.right * (horizontalInput * walkSpeed);
    }

    private void RotateCharacter()
    {
        this.transform.Rotate(new Vector3(0.0f, mouseInputX, 0.0f));
    }
}
