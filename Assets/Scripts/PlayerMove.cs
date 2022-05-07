using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController charController;
    private CharacterAnimations playerAnimations;

    public float movementSpeed = 3f;
    public float gravity = 9.8f;
    public float rotationSpeed = 0.15f;
    public float rotateDegreesPerSecond = 100f;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        playerAnimations = GetComponent<CharacterAnimations>();
    }

    private void Update()
    {
        Move();
        Rotate();
        AnimateWalk();
    }

    private void Move()
    {
        Vector3 foward = Input.GetAxis("Vertical") * transform.forward * movementSpeed;
        if (!charController.isGrounded)
            foward.y -= gravity * Time.deltaTime;

        charController.Move(foward * Time.deltaTime);
    }

    private void Rotate()
    {
        Vector3 rotationDirection = Vector3.zero;

        if (Input.GetAxis("Horizontal") < 0)
        {
            rotationDirection = transform.TransformDirection(Vector3.left);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            rotationDirection = transform.TransformDirection(Vector3.right);
        }

        if (rotationDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(rotationDirection), rotateDegreesPerSecond * Time.deltaTime);
        }
    }

    void AnimateWalk()
    {
        if(charController.velocity.sqrMagnitude != 0f)
        {
            playerAnimations.Walk(true);
        }
        else
        {
            playerAnimations.Walk(false);
        }
    }
}
