using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMechanics : MonoBehaviour
{
    public float speedWalk;
    public float speedSprint;
    public float jumpPower;

    private float gravityForce;
    private Vector3 moveVector;

    private CharacterController characterController;
    private Animator animator;

    private ControllerWalk walkController;
    private ControllerJump jumpController;
    private ControllerSprint sprintController;
    private ControllerHit hitController;
    private ControllerPut putController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        walkController = GameObject.FindGameObjectWithTag("ControllerWalk").GetComponent<ControllerWalk>();
        jumpController = GameObject.FindGameObjectWithTag("ControllerJump").GetComponent<ControllerJump>();
        sprintController = GameObject.FindGameObjectWithTag("ControllerSprint").GetComponent<ControllerSprint>();
        hitController = GameObject.FindGameObjectWithTag("ControllerHit").GetComponent<ControllerHit>();
        putController = GameObject.FindGameObjectWithTag("ControllerPut").GetComponent<ControllerPut>();
    }

    private void Update()
    {
        CharacterMove();
        GamingGravity();
    }

    private void CharacterMove()
    {
        if (characterController.isGrounded)
        {
            animator.ResetTrigger("Jump");
            animator.SetBool("Falling", false);

            moveVector = Vector3.zero;
            moveVector.x = walkController.Horizontal() * speedWalk;
            moveVector.z = walkController.Vertical() * speedWalk;

            if (moveVector.x != 0 || moveVector.z != 0) animator.SetBool("Walk", true);
            else animator.SetBool("Walk", false);

            if (Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
            {
                Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, speedWalk, 0.0f);
                transform.rotation = Quaternion.LookRotation(direct);
            }
        }
        else
        {
            if (gravityForce < -3f) animator.SetBool("Falling", true);
        }





        moveVector.y = gravityForce;
        characterController.Move(moveVector * Time.deltaTime);
    }

    private void GamingGravity()
    {
        if (!characterController.isGrounded) gravityForce -= 20f * Time.deltaTime;
        else gravityForce = -1f;
        if (jumpController.JumpCharacter() && characterController.isGrounded)
        {
            gravityForce = jumpPower;
            animator.SetTrigger("Jump");
        }
    }
}
