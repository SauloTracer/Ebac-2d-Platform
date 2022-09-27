using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Player : MonoBehaviour
{
    [Header("Controls")]
    public KeyCode left = KeyCode.LeftArrow;
    public KeyCode right = KeyCode.LeftArrow;
    public KeyCode jump = KeyCode.Space;
    public KeyCode running = KeyCode.LeftControl;

    [Header("Movement Settings")]
    public float speed = 3f;
    public float runningSpeed = 5f;
    public float jumpForce = 8f;
    public Vector2 friction = new Vector2(0.1f, 0);

    [Header("Animation Settings")]
    public Vector3 jumpScale = new Vector3(.7f, 1.2f, 1f);
    public float jumpAnimationDuration = .2f;
    public Vector3 landScale = new Vector3(1.4f, 0.6f, 1f);
    public float landAnimationDuration = .2f;
    public Ease ease = Ease.OutBack;

    public float deathAnimationDuration = .5f;

    [Header("References")]
    public Rigidbody2D rigidBody;
    public Animator animator;
    public float GroundRayOffset = -0.5f;
    public float MinYPosition = -17f;

    public string moving = "Moving";
    public string falling = "Falling";
    public string jumping = "Jumping";
    public string grounded = "Grounded";
    public string landing = "Landing";
    public string dying = "Death";

    private Vector3 _startPosition;
    private Vector3 _startScale;
    private Health _health;

    private bool _wasInTheAir;

    private void OnValidate()
    {
        if (rigidBody == null)
            rigidBody = GetComponent<Rigidbody2D>();

        if (animator == null)
            animator = GetComponentInChildren<Animator>();
    }

    void Awake()
    {
        _startPosition = transform.position;
        _startScale = transform.localScale;
        _wasInTheAir = true;
        _health = GetComponent<Health>();
        _health.OnDeath += AnimateDeath;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleJump();
        HandleFall();
        HandleLanding();
        HandleDrag();
        HandleFallOut();
        _wasInTheAir = !IsGrounded();

        var startPosition = transform.position;
        startPosition.y -= GetComponent<BoxCollider2D>().bounds.extents.y + GroundRayOffset;
        Debug.DrawRay(startPosition, Vector2.down * 0.1f, Color.red);
    }

    private void HandleMovement()
    {
        float currentSpeed = IsRunning() ? runningSpeed : speed;
        if (Input.GetKey(left))
        {
            rigidBody.velocity = new Vector2(-currentSpeed, rigidBody.velocity.y);
            rigidBody.transform.DOScaleX(-1, 0.1f);
            animator.SetBool(moving, true);
        }
        else if (Input.GetKey(right))
        {
            rigidBody.velocity = new Vector2(currentSpeed, rigidBody.velocity.y);
            rigidBody.transform.DOScaleX(1, 0.1f);
            animator.SetBool(moving, true);
        } else {
            animator.SetBool(moving, false);
        }
    }

    private void HandleJump() {
        bool isGrounded = IsGrounded();
        if (_wasInTheAir && isGrounded) animator.SetBool(jumping, false);
        if (Input.GetKeyDown(jump) && isGrounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            animator.SetBool(jumping, true);
            animator.SetBool(grounded, false);
        }
    }

    private void HandleFall() {
        bool isFalling = IsFalling();
        if (isFalling) animator.SetBool(jumping, false);
        animator.SetBool(falling, isFalling);
    }

    private void HandleLanding()
    {
        bool isGrounded = IsGrounded();
        animator.SetBool(grounded, isGrounded);
        if (_wasInTheAir && isGrounded) animator.SetTrigger(landing);
    }

    private void HandleDrag() {
        if (rigidBody.velocity.x == 0) return;
        int signal = rigidBody.velocity.x > 0 ? -1 : 1;
        rigidBody.velocity = (Mathf.Abs(rigidBody.velocity.x) < friction.x) 
            ? new Vector2(0, rigidBody.velocity.y) 
            : new Vector2(rigidBody.velocity.x + friction.x * signal, rigidBody.velocity.y);
    }

    private void HandleFallOut() {
        if (IsFallingOut())
        {
            Reset();
        }
    }

    public void Reset() {
        transform.position = _startPosition;
        transform.localScale = _startScale;
    }
    
    private bool IsGrounded() {
        var startPosition = transform.position;
        startPosition.y -= GetComponent<BoxCollider2D>().bounds.extents.y + GroundRayOffset;
        return Physics2D.Raycast(startPosition, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
    }

    private bool IsRunning() {
        return Input.GetKey(running);
    }

    private bool IsFalling() {
        return rigidBody.velocity.y < 0 && !IsGrounded();
    }

    private bool IsFallingOut() {
        return transform.position.y < MinYPosition;
    }

    private void AnimateDeath() {
        animator.SetTrigger(dying);
        StartCoroutine(nameof(DelayReset));
    }

    private IEnumerator DelayReset() {
        yield return new WaitForSeconds(deathAnimationDuration);
        Reset();
    }
}
