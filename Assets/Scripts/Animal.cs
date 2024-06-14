using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{

    protected virtual void MoveAnimal(float speed, Rigidbody body)
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        float smootForward = speed * Time.fixedDeltaTime;

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput).normalized;

        body.AddForce(direction * smootForward, ForceMode.Impulse);

    }

    protected virtual void RotateAnimal(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            // Smooth rotate
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.05f);
        }

    }



}
