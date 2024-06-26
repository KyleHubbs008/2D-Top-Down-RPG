using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 movement;
    
    private Rigidbody2D rb;
    private Animator animator;

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update() 
    {
        movement.Set(InputManager.Movement.x, InputManager.Movement.y);

        /**
         * Since we are setting the velocity directly, we don't need to multiply 
         * the movement vector by Time.deltaTime.
         */
        rb.velocity = movement * moveSpeed;

        animator.SetFloat(horizontal, movement.x);
        animator.SetFloat(vertical, movement.y);

        if (movement != Vector2.zero) {
            animator.SetFloat(lastHorizontal, movement.x);
            animator.SetFloat(lastVertical, movement.y);
        }
    }
}
