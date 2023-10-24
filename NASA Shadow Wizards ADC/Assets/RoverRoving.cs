using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverRoving : MonoBehaviour
{
    public Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.AddForce(transform.forward * 10, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.AddForce(transform.forward * (-10), ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(transform.right * (-10), ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(transform.right * 10, ForceMode.Force);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(transform.up * 3, ForceMode.Impulse);
        }

        
    }
}
