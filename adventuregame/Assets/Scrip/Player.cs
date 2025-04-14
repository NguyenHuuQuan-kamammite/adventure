using UnityEngine;

public class Player : MonoBehaviour
{
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
    #endregion

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(stateMachine, this, "Idle");
        moveState = new PlayerMoveState(stateMachine, this, "Move");
        jumpState = new PlayerJumpState(stateMachine, this, "Jump");
        airState = new PlayerAirState(stateMachine, this, "Jump");
        dashState = new PlayerDashState(stateMachine, this, "Dash");
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
    private void CheckForDashInput()
    {
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

public void SetVelocity(float velocityX, float velocityY)
    {
        rb.linearVelocity= new Vector2(velocityX, velocityY);
    }
public bool IsGroundDeteced() => Physics2D.Raycast(groundLayer.position, Vector2.down, groundCheckDistance, WhatisGround);
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
      Gizmos.DrawLine(groundLayer.position, new Vector3(groundLayer.position.x, groundLayer.position.y - groundCheckDistance));  
       Gizmos.color = Color.blue;
      Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance , wallCheck.position.y));
    }
    public void Flip()
    {
        isFacingDir = isFacingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void FlipController(float _x)
    {
        if(_x > 0 && !facingRight)
        {
            Flip();
        }
        else if(_x < 0 && facingRight)
        {
            Flip();
        }
    }
}