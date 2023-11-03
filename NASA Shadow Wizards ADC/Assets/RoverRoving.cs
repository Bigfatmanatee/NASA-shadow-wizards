using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverRoving : MonoBehaviour
{
    public float spd = 5;

    public Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {


    }
    // Update is called once per frame
    void Update()
    {
        float x;
        float y;

        x = Input.GetAxis("Horizontal") * spd;
        y = Input.GetAxis("Vertical") * spd;

        rigidbody.velocity = (transform.right * x + transform.forward * y) + transform.up * (-1);

       /* if (Input.GetKey(KeyCode.W))
        {
            rigidbody.AddForce(transform.forward * spd, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.AddForce(transform.forward * (spd * -1), ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(transform.right * (spd * -1), ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(transform.right * spd, ForceMode.Force);
        }
       */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(transform.up * 3, ForceMode.Impulse);
        }
       
        
    }
}
