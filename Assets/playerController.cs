using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float movementSpeed = 6f;
    public Vector3 movementVector;

    private float mouseX;
    private float mouseY;
    public Camera cachedCamera;

    private Rigidbody rb;
    private Animator animator;
    private float deltaRadial;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movementVector = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        deltaRadial = Mathf.Abs(Input.GetAxis("Horizontal") * Input.GetAxis("Vertical")) > 0f ? 0.7f : 1f;
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + movementVector * deltaRadial * movementSpeed * Time.fixedDeltaTime);
    }
}
