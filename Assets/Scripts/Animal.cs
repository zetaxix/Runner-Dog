using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{

    protected virtual void MoveAnimal(float speed)
    {
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * verticalInput * speed * Time.fixedDeltaTime);
    
    }

    protected virtual void RotateAnimal(float rotateSpeed)
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * horizontalInput * rotateSpeed *Time.fixedDeltaTime, Space.World);
        
    }



}
