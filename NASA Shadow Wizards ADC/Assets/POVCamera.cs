using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POVCamera : MonoBehaviour
{
    public Transform capsule;
    public float snstvy;
    private float xRot;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX;
        float mouseY;

        mouseX = Input.GetAxis("Mouse X") * snstvy;
        mouseY = Input.GetAxis("Mouse Y") * snstvy;
        xRot -= mouseY;
        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        xRot = Mathf.Clamp(xRot, -90, 90);
        //transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x + mouseX, transform.rotation.y, transform.rotation.z));
        //capsule.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y + mouseX, transform.rotation.z));
        capsule.transform.Rotate(new Vector3(0, mouseX, 0));
        //transform.Rotate(new Vector3(mouseY * -1, 0, 0));
        //transform.eulerAngles = new Vector3(Mathf.Clamp(transform.eulerAngles.x + 90, -90 + 90, 90 + 90), transform.eulerAngles.y, transform.eulerAngles.z);
        //print(Mathf.Clamp(transform.eulerAngles.x + 90, -90 + 90, 90 + 90));
   /*     if (transform.eulerAngles.x < 90 && mouseY < 0)
        {
            transform.Rotate(new Vector3(mouseY * -1, 0, 0));
        }
        else if (transform.eulerAngles.x > -90 && mouseY > 0)
        {
            transform.Rotate(new Vector3(mouseY * -1, 0, 0));
        }
 */
    }
}
