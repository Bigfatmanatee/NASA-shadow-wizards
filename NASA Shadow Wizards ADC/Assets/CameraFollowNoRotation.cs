using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowNoRotation : MonoBehaviour
{
    public Transform HappyChaos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (HappyChaos.position) - new Vector3(20,0,0);
        
    }
}
