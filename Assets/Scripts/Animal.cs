using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{

    protected virtual void MoveAnimal(float speed)
    {
        float verticalInput = Input.GetAxis("Vertical");
        float smootForward = verticalInput * speed * Time.fixedDeltaTime;

        Vector3 direction = Vector3.forward;

        transform.Translate(direction * smootForward);
    
    }

    protected virtual void RotateAnimal(float rotateSpeed)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float smoothRotation = horizontalInput * rotateSpeed * Time.fixedDeltaTime;

        Vector3 direction = Vector3.up;

        transform.Rotate(direction * smoothRotation, Space.World);
        
    }



}
