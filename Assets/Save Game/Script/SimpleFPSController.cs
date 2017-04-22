using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SimpleFPSController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float mouseXSensitivity;
    [SerializeField]
    private float mouseYSensitivity; 

    private Vector3 movementUpdate;
    private Vector3 lookUpdate;
    
    void Update()
    {
        this.UpdateLook();
        this.UpdateMovement();        
    }

    private void UpdateLook()
    {
        float xRot = Input.GetAxis("Mouse Y") * this.mouseYSensitivity;
        float yRot = Input.GetAxis("Mouse X") * this.mouseXSensitivity;

        this.transform.localRotation *= Quaternion.Euler(0, yRot, 0);
        Camera.main.transform.localRotation *= Quaternion.Euler(-xRot, 0, 0);
    }

    private void UpdateMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");                

        if (h != 0 || v != 0)
        {
            this.transform.position += (this.transform.forward * v + this.transform.right * h) * this.speed * Time.deltaTime; 
        }
    }

    internal void SetForward(Vector3 forward)
    {
        this.transform.localRotation = Quaternion.LookRotation(forward, Vector3.up);
        Camera.main.transform.localRotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);                    
    }
}
