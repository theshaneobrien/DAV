using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotateAround : MonoBehaviour
{
    //Assign a GameObject in the Inspector to rotate around
    //public GameObject target;

    public float speed = 3;

    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
            transform.RotateAround(transform.position, -Vector3.up, speed * Input.GetAxis("Mouse X"));
            transform.RotateAround(transform.position, transform.right, speed * Input.GetAxis("Mouse Y"));
        //}

        // Spin the object around the target at 20 degrees/second.
        //transform.RotateAround(target.transform.position, Vector3.right, 20 * Time.deltaTime);
    }
}
