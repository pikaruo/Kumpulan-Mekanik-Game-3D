using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRunPlayerController : MonoBehaviour
{
    [Header("System Character Movement")]
    private CharacterController characterController;
    private Vector3 direction;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float maxSpeed;

    private int disiredLane = 1; // 0: left, 1: middle, 2: right
    [SerializeField] private float laneDistance = 4; // the distance between two lanes

    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity = -20;

    private bool isSliding;

    [Header("System Animator")]
    [SerializeField] private Animator animator;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (EndlessRunGameManager.isGmeStarted == false)
        {
            return;
        }
        else
        {
            animator.SetBool("IsGameStarted", true);

            if (forwardSpeed < maxSpeed)
            {
                forwardSpeed += 0.1f * Time.deltaTime;
            }

            direction.z = forwardSpeed;

            MoveLeftRight();

            Jump();

            Sliding();
        }
    }

    private void FixedUpdate()
    {
        if (EndlessRunGameManager.isGmeStarted == false)
        {
            return;
        }
        else
        {
            characterController.Move(direction * Time.fixedDeltaTime);
        }
    }

    // * This method for move to left or right
    private void MoveLeftRight()
    {
        //* Gather the inputs on which lane we should be

        if (EndlessRunSwipeManager.swipeLeft)
        {
            Debug.Log("A");
            disiredLane--;
            if (disiredLane == -1)
            {
                disiredLane = 0;
            }
        }

        if (EndlessRunSwipeManager.swipeRight)
        {
            Debug.Log("D");
            disiredLane++;
            if (disiredLane == 3)
            {
                disiredLane = 2;
            }
        }

        // * Calculate where we should be in the future

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (disiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (disiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        //transform.position = targetPosition;
        if (transform.position == targetPosition)
        {
            return;
        }
        else
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            {
                characterController.Move(moveDir);
            }
            else
            {
                characterController.Move(diff);
            }
        }

    }

    // * This method for jump
    private void Jump()
    {


        // animator.SetBool("IsGrounded", characterController.isGrounded);

        if (characterController.isGrounded)
        {
            if (EndlessRunSwipeManager.swipeUp)
            {
                animator.Play("jump_animation");
                direction.y = jumpForce;
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
        }

    }

    // * This method for sliding
    private void Sliding()
    {
        if (EndlessRunSwipeManager.swipeDown && isSliding == false)
        {
            StartCoroutine(Slide());
        }
    }

    // * This IEnumerator for sliding
    private IEnumerator Slide()
    {
        isSliding = true;
        animator.Play("sliding_animation");
        characterController.center = new Vector3(0, -0.5f, 0);
        characterController.height = 1;

        yield return new WaitForSeconds(1.3f);

        characterController.center = new Vector3(0, 0, 0);
        characterController.height = 2;
        isSliding = false;
    }

    // * This method for check player hit obstacle
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.CompareTag("Obstacle"))
        {
            EndlessRunGameManager.isGameover = true;
        }
    }

}
