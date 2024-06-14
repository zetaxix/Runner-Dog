using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal
{
    [Header("References")]
    [SerializeField] float catSpeed;
    Rigidbody rb;
    [SerializeField] GameObject dogPrefab;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    

    protected override void MoveAnimal(float speed, Rigidbody body)
    {


    }
}
