using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Controls")]
    public KeyCode left = KeyCode.LeftArrow;
    public KeyCode right = KeyCode.LeftArrow;
    public KeyCode jump = KeyCode.Space;

    [Header("Movement Configruations")]
    public float speed = 3f;
    public float jumpForce = 8f;
    public Vector2 friction = new Vector2(0.1f, 0);

    public Rigidbody2D rigidBody;

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleJump();
        DecreaseSpeed();
        var startPosition = transform.position;
        startPosition.y -= GetComponent<BoxCollider2D>().bounds.extents.y;
        Debug.DrawRay(startPosition, Vector2.down * 0.1f, Color.red);
    }

    private void HandleMovement()
    {
        if (Input.GetKey(left))
        {
            rigidBody.velocity = new Vector2(-speed, rigidBody.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
        }
    }

    private void HandleJump() {
        if (Input.GetKeyDown(jump) && IsGrounded())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        }
    }

    private void DecreaseSpeed() {
        if (rigidBody.velocity.x == 0) return;
        int signal = rigidBody.velocity.x > 0 ? -1 : 1;
        rigidBody.velocity = (Mathf.Abs(rigidBody.velocity.x) < friction.x) 
            ? new Vector2(0, rigidBody.velocity.y) 
            : new Vector2(rigidBody.velocity.x + friction.x * signal, rigidBody.velocity.y);
    }

    private bool IsGrounded() {
        var startPosition = transform.position;
        startPosition.y -= GetComponent<BoxCollider2D>().bounds.extents.y;
        return Physics2D.Raycast(startPosition, Vector2.down, 0.1f);
    }
}
