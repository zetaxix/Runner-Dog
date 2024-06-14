using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal
{
    [Header("References")]

    [SerializeField] float dogspeed = 3;

    private Animator animator;

    Rigidbody rb;

    bool canMove = true;
    bool isSitting = false;

    [Header("Camera Settings")]

    public Transform cameraTransform;

    [SerializeField] float turnSmoothVelocity;
    [SerializeField] float turnSmoothTime = 0.1f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            dogspeed = 6;
        }else
        {
            dogspeed = 3;
        }

        MoveAnimal(dogspeed, rb);
    }

    protected override void MoveAnimal(float speed, Rigidbody body)
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput).normalized;

        DogAnimController(direction);

        if (direction.magnitude >= 0.1f && canMove)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0).normalized * Vector3.forward.normalized;

            body.MovePosition(transform.position + moveDirection * speed * Time.fixedDeltaTime);
        }
    }

    void DogAnimController(Vector3 direction)
    {
        #region Walking Anim Controller
        if (Mathf.Abs(direction.magnitude) > 0.1)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        #endregion

        #region Running Anim Controller
        if (Input.GetKey(KeyCode.LeftShift))
        {
            direction = direction.normalized * (direction.magnitude + 1);
        }
        else
        {
            direction = direction.normalized * (direction.magnitude);
        }

        if (Mathf.Abs(direction.magnitude) > 1)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
        #endregion

        #region Barking Anim Controller
        if (Input.GetKey(KeyCode.E) && direction.magnitude == 0)
        {
            StartCoroutine(BarkAnimController());
        }
        #endregion

        #region Sitting Anim Controller

        if (Input.GetKey(KeyCode.F))
        {
            ToggleSitting();
        }

        #endregion
    }

    IEnumerator BarkAnimController()
    {
        canMove = false;
        animator.SetBool("IsBarking", true);
        yield return new WaitForSeconds(5.50f);
        animator.SetBool("IsBarking", false);
        canMove = true;
    }

    void ToggleSitting()
    {
        isSitting = !isSitting; // Oturma durumu tersine çevrilir
        canMove = !isSitting; // Hareket edebilme durumu oturma durumuna baðlý olarak güncellenir
        animator.SetBool("IsSitting", isSitting); // Animasyon durumu güncellenir
    }

}
