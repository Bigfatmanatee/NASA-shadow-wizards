using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HAPPYCHAOSFBJASFLBASFKJLSAJHFASHBLKFHJASFJHKASJFKAKSLFAHLSJ : MonoBehaviour
{
    public Rigidbody hc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hc.AddForce(new Vector3(100,0,0), ForceMode.Acceleration);
        hc.AddTorque(new Vector3(100, 142904120, 100));
    }
}
