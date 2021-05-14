using System;
using BoundfoxStudios.MiniDash.Collectables;
using BoundfoxStudios.MiniDash.Events.ScriptableObjects;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BoundfoxStudios.MiniDash.Player
{
  public class PlayerCharacter : MonoBehaviour
  {
    private enum DashDirection
    {
      None,
      Left,
      Right,
    }

    public GameControls Controls;

    [Header("References")]
    public Animator Animator;

    public Rigidbody2D Rigidbody;
    public SpriteRenderer SpriteRenderer;
    public BoxCollider2D StandingCollider;
    public BoxCollider2D DashingCollider;

    [Header("Configuration")]
    public float MovementSpeed = 1;

    public float DashSpeed = 10;

    public float JumpForce = 10;

    [Header("Ground")]
    public bool IsGrounded;

    public Transform GroundCheck;
    public float GroundRadius = 0.1f;
    public LayerMask GroundMask;

    [Header("Events")]
    public VoidEventSO PlayerDiedEventSO;
    
    private bool _isFacingLeft = true;
    private DashDirection _dashDirection;
    private float _gravityScale;
    private float _horizontalMovement;
    private float _verticalMovement;
    private bool _setJumpAnimationTrigger;
    private bool _waitForBeingOnGroundBeforeNextMovement;

    private static readonly int GroundedAnimatorProperty = Animator.StringToHash("IsGrounded");
    private static readonly int HorizontalMovementAnimatorProperty = Animator.StringToHash("HorizontalDirection");
    private static readonly int VerticalMovementAnimatorProperty = Animator.StringToHash("VerticalDirection");
    private static readonly int DoJumpAnimatorProperty = Animator.StringToHash("DoJump");
    private static readonly int IsDashingAnimatorProperty = Animator.StringToHash("IsDashing");

    private void Awake()
    {
      DashingCollider.enabled = false;
      Controls = new GameControls();
    }

    private void OnEnable()
    {
      var groundControls = Controls.PlayerGround;

      groundControls.LeftRight.performed += LeftRightPerformed;
      groundControls.LeftRight.canceled += LeftRightPerformed;
      groundControls.JumpDash.performed += JumpDashPerformed;

      groundControls.Enable();
    }

    private void JumpDashPerformed(InputAction.CallbackContext obj)
    {
      if (!IsGrounded)
      {
        if (!_waitForBeingOnGroundBeforeNextMovement && _dashDirection == DashDirection.None)
        {
          StartDash(_isFacingLeft ? DashDirection.Left : DashDirection.Right);
        }

        return;
      }

      Rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
      _setJumpAnimationTrigger = true;
    }

    private void OnDisable()
    {
      var groundControls = Controls.PlayerGround;

      groundControls.LeftRight.performed -= LeftRightPerformed;
      groundControls.LeftRight.canceled -= LeftRightPerformed;
      groundControls.JumpDash.performed -= JumpDashPerformed;

      groundControls.Disable();
    }

    public void OnLevelCompleted()
    {
      Controls.PlayerGround.Disable();
    }

    private void StartDash(DashDirection direction)
    {
      StandingCollider.enabled = false;
      DashingCollider.enabled = true;
      _dashDirection = direction;
      _waitForBeingOnGroundBeforeNextMovement = true;

      _gravityScale = Rigidbody.gravityScale;
      Rigidbody.gravityScale = 0;
    }

    private void StopDash()
    {
      if (_dashDirection == DashDirection.None)
      {
        return;
      }

      DashingCollider.enabled = false;
      StandingCollider.enabled = true;
      Rigidbody.gravityScale = _gravityScale;
      _dashDirection = DashDirection.None;
      _horizontalMovement = 0;
    }

    private void FixedUpdate()
    {
      CheckGround();

      if (_waitForBeingOnGroundBeforeNextMovement && IsGrounded)
      {
        _waitForBeingOnGroundBeforeNextMovement = false;
      }

      Movement();
      UpdateAnimations();
    }

    private void Movement()
    {
      if (_dashDirection == DashDirection.None)
      {
        if (!_waitForBeingOnGroundBeforeNextMovement)
        {
          var velocity = Rigidbody.velocity;
          Rigidbody.velocity = new Vector2(_horizontalMovement * MovementSpeed, velocity.y);
        }
      }
      else
      {
        _horizontalMovement = _dashDirection == DashDirection.Left ? -1 : 1;
        Rigidbody.velocity = new Vector2(_horizontalMovement * DashSpeed, 0);
      }

      _verticalMovement = Rigidbody.velocity.y;
    }

    private void UpdateAnimations()
    {
      if (_horizontalMovement > 0 && _isFacingLeft)
      {
        SpriteRenderer.flipX = true;
        _isFacingLeft = false;
      }
      else if (_horizontalMovement < 0 && !_isFacingLeft)
      {
        SpriteRenderer.flipX = false;
        _isFacingLeft = true;
      }

      Animator.SetBool(GroundedAnimatorProperty, IsGrounded && !_setJumpAnimationTrigger);
      Animator.SetFloat(HorizontalMovementAnimatorProperty, _horizontalMovement);
      Animator.SetFloat(VerticalMovementAnimatorProperty, _verticalMovement);
      Animator.SetBool(IsDashingAnimatorProperty, _dashDirection != DashDirection.None);

      if (_setJumpAnimationTrigger)
      {
        _setJumpAnimationTrigger = false;
        Animator.SetTrigger(DoJumpAnimatorProperty);
      }
    }

    private void CheckGround()
    {
      var collision = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, GroundMask);

      IsGrounded = collision;
    }

    private void LeftRightPerformed(InputAction.CallbackContext context)
    {
      _horizontalMovement = context.ReadValue<float>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag("Collectable"))
      {
        var collectable = other.GetComponent<Collectable>();

        if (collectable)
        {
          collectable.Collect();
        }
      }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
      if (_dashDirection != DashDirection.None && (GroundMask & 1 << other.gameObject.layer) == GroundMask)
      {
        StopDash();
      }
    }
    
    public void OnPlayerOutsideOfCamera()
    {
      Destroy(gameObject);
      PlayerDiedEventSO.RaiseEvent();
    }
  }
}
