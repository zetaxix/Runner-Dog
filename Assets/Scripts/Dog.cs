using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal
{
    [SerializeField] float dogspeed;

    private Animator animator;

    Rigidbody rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveAnimal(dogspeed, rb);

        DogAnimController();
    }

    void DogAnimController()
    {
        // E�er yerdeyse ve h�z� 0.1f'den b�y�kse "Walk" animasyonuna ge�i� yapal�m.
        if (Mathf.Abs(rb.velocity.magnitude) > 0.08)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }


}
