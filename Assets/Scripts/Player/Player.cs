using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using utils;

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


    [Header("References")]
    public Rigidbody2D rigidBody;

    private Vector3 _startPosition;
    private Vector3 _startScale;
    private Color _startColor;

    private bool _wasInTheAir;



    void Awake()
    {
        _startPosition = transform.position;
        _startColor = GetComponent<SpriteRenderer>().color;
        _startScale = transform.localScale;
        _wasInTheAir = true;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleJump();
        HandleLanding();
        HandleDrag();
        HandleFall();
        _wasInTheAir = !IsGrounded();

        var startPosition = transform.position;
        startPosition.y -= GetComponent<BoxCollider2D>().bounds.extents.y;
        Debug.DrawRay(startPosition, Vector2.down * 0.1f, Color.red);
    }

    private void HandleMovement()
    {
        float currentSpeed = IsRunning() ? runningSpeed : speed;
        if (Input.GetKey(left))
        {
            rigidBody.velocity = new Vector2(-currentSpeed, rigidBody.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            rigidBody.velocity = new Vector2(currentSpeed, rigidBody.velocity.y);
        }
    }

    private void HandleJump() {
        if (Input.GetKeyDown(jump) && IsGrounded())
        {
            DOTween.Kill(rigidBody.transform);
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            AnimateJump();
        }
    }

    private void HandleLanding()
    {
        if (!_wasInTheAir) return;
        if(IsGrounded())
        {
            DOTween.Kill(rigidBody.transform);
            AnimateLanding();
        }
    }

    private void HandleDrag() {
        if (rigidBody.velocity.x == 0) return;
        int signal = rigidBody.velocity.x > 0 ? -1 : 1;
        rigidBody.velocity = (Mathf.Abs(rigidBody.velocity.x) < friction.x) 
            ? new Vector2(0, rigidBody.velocity.y) 
            : new Vector2(rigidBody.velocity.x + friction.x * signal, rigidBody.velocity.y);
    }

    private void HandleFall() {
        if (IsFalling())
        {
            transform.position = _startPosition;
            GetComponent<SpriteRenderer>().color = _startColor;
        }
    }
    
    private bool IsGrounded() {
        var startPosition = transform.position;
        startPosition.y -= GetComponent<BoxCollider2D>().bounds.extents.y;
        return Physics2D.Raycast(startPosition, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
    }

    private bool IsRunning() {
        return Input.GetKey(running);
    }

    private bool IsFalling() {
        return transform.position.y < 4.5f;
    }

    private void AnimateJump() {
        rigidBody.transform.DOScale(jumpScale, jumpAnimationDuration)
            .SetLoops(2, LoopType.Yoyo)
            .SetEase(ease)
            .OnComplete(() => {
                rigidBody.transform.localScale = _startScale;
            });
    }

    private void AnimateLanding() {
        rigidBody.transform.DOScale(landScale, landAnimationDuration)
            .SetLoops(2, LoopType.Yoyo)
            .SetEase(ease)
            .OnComplete(() => {
                rigidBody.transform.localScale = _startScale;
            });
    }

}
