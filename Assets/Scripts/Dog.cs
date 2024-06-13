using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal
{
    [SerializeField] float dogspeed;
    [SerializeField] float dogRotate;

    private void FixedUpdate()
    {
        MoveAnimal(dogspeed);
        RotateAnimal(dogRotate);
    }

}
