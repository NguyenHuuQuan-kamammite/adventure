using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Attack Details")]
    public Vector2[] attackMovement ;
    public bool isBussy { get; private set; }
    [Header("Move Info")]
    public float moveSpeed = 12f;
    public float jumpForce ;
    [Header("Dash Info")]
    [SerializeField] private float dashCooldown ;
    [SerializeField] private float dashTime ;
    public float dashSpeed ;
    public float dashDuration ;
    public float dashDir {get; private set; }
    [Header("Colision Info")]
    [SerializeField] private Transform groundLayer;
    [SerializeField] private float groundCheckDistance ;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance ;
    [SerializeField] private LayerMask WhatisGround;

    public int isFacingDir { get; private set; } = 1;
    private bool facingRight = true;

    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }

    #region State
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerWallSlideState wallSlideState { get; private set; }
   public PlyerWallJumpState wallJump { get; private set; }

    public PlayerPrimaryAttack primaryAttack { get; private set; }
    #endregion

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(stateMachine, this, "Idle");
        moveState = new PlayerMoveState(stateMachine, this, "Move");
        jumpState = new PlayerJumpState(stateMachine, this, "Jump");
        airState = new PlayerAirState(stateMachine, this, "Jump");
        dashState = new PlayerDashState(stateMachine, this, "Dash");
        wallSlideState = new PlayerWallSlideState(stateMachine, this, "WallSlide");
        wallJump = new PlyerWallJumpState(stateMachine, this, "Jump");
        primaryAttack = new PlayerPrimaryAttack(stateMachine, this, "Attack");
    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stateMachine.Initialize(idleState);
        

    }
    

    private void Update()
    {
        stateMachine.currentState.Update();
        FlipController(rb.linearVelocity.x); 
        CheckForDashInput();
           
        
    }
    public IEnumerator BusyFor(float _sec)
    {
        isBussy = true;
     
        yield return new WaitForSeconds(_sec);
        isBussy = false;
     
    }
    private void CheckForDashInput()
    {   
        if(IsWallDetected())
        {
            return;
        }
        dashTime -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashTime <= 0)
        {
            dashTime = dashCooldown;
            dashDir = Input.GetAxisRaw("Horizontal");
            if (dashDir == 0)
            {
                dashDir = isFacingDir;
            }
            stateMachine.ChangeState(dashState);
        }
    }
    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();


public void ZeroVelocity()
    {
        rb.linearVelocity = new Vector2(0, 0);
    }
public void SetVelocity(float velocityX, float velocityY)
    {
        rb.linearVelocity= new Vector2(velocityX, velocityY);
    }
#region Colision
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        }
    }
public bool IsGroundDeteced() => Physics2D.Raycast(groundLayer.position, Vector2.down, groundCheckDistance, WhatisGround);
public bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * isFacingDir, wallCheckDistance, WhatisGround);
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
      Gizmos.DrawLine(groundLayer.position, new Vector3(groundLayer.position.x, groundLayer.position.y - groundCheckDistance));  
       Gizmos.color = Color.blue;
      Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance , wallCheck.position.y));
    }

#endregion
    public void Flip()
    {
        isFacingDir = isFacingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void FlipController(float _x)
    {
        if (Mathf.Abs(_x) < 0.01f) return; 
        if (_x > 0 && !facingRight)
        {
            Flip();
        }
        else if (_x < 0 && facingRight)
        {
            Flip();
        }
    }
}