// This code is designed to control the player's movements, including animations and positional transitions.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerState : MonoBehaviour
{
    Animator animator; // Reference to the Animator component.

    private float transitionSpeed = 1f; // Speed of the transition.

    private bool isTransitioning = false; // Flag to check if transitioning is in progress.

    public Animator getAnimator() {
        return animator;
    }

    public void setAnimator(Animator _animator) {
        animator = _animator;
    }

    public float getTransitionSpeed() {
        return transitionSpeed;
    }

    public void setTransitionSpeed(float _transitionSpeed) {
        transitionSpeed = _transitionSpeed;
    }
    public bool getIsTransitioning() {
        return isTransitioning;
    }

    public void setIsTransitioning(bool _isTransitioning) {
        isTransitioning = _isTransitioning;
    }

    public void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component attached to this GameObject.
    }


    // Rule: Player's movement consists of three actions: jumping up, moving left and moving right. 
    // Update(): detects the player's keyboard inputs (W, A, D keys) and triggers corresponding actions based on these inputs.
    public void Update()
    {
        // Check for the "W" key press to trigger a jump animation.
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(Jump(() =>
            {
                animator.SetBool("IsJump", false); // Reset the "IsJump" parameter in the Animator.
            }));
        }

        // Check for the "A" key press to transition to the left lane (if not already transitioning and within a certain position).
        if (Input.GetKeyDown(KeyCode.A) && !isTransitioning && transform.position.x > 430)
        {
            StartCoroutine(TransitionToLane(new Vector3(-14f, 0, 0))); // Transition to the left lane.
        }

        // Check for the "D" key press to transition to the right lane (if not already transitioning and within a certain position).
        if (Input.GetKeyDown(KeyCode.D) && !isTransitioning && transform.position.x < 458)
        {
            StartCoroutine(TransitionToLane(new Vector3(14f, 0, 0))); // Transition to the right lane.
        }
    }


    // Jump(): Triggers the jump animation.
    // Once the animation is complete, a callback function is called to reset the animation parameters. 
    public IEnumerator Jump(UnityAction callBack)
    {
        animator.SetBool("IsJump", true); // Trigger the jump animation.
        yield return null;
        callBack.Invoke(); // Invoke the callback function after the animation completes.
    }

    // TransitionToLane(): smoothly moves the player to a specified lane (position).
    // Method: Calculates the target position and direction vector.
    // Gradually moves the player to the target position using the transform.Translate method.
    // Resets the isTransitioning flag after the movement is complete.
    public IEnumerator TransitionToLane(Vector3 offsetx)
    {
        isTransitioning = true; // Set the transitioning flag to true.
        Vector3 tempTargetPosition = transform.position + offsetx; // Calculate the target position.
        Vector3 targetPosition = tempTargetPosition - transform.position; // Calculate the direction vector.

        while (Vector3.Distance(transform.position, tempTargetPosition) > 0.1f)
        {
            transform.Translate(targetPosition.normalized * 0.2f); // Move the player gradually toward the target position.
            yield return null;
        }

        isTransitioning = false; // Set the transitioning flag to false when done.
    }
}
