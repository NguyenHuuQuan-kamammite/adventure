using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {

    }
    public override void Enter()
    {
        base.Enter();

    }
    public override void Exit()
    {
        base.Exit();
     
    }
    public override void Update()
    {
        base.Update();
        if(xInput != 0)
        {
           if(player.isFacingDir != xInput)
            {
               stateMachine.ChangeState(player.idleState);
            }
        }
        if(yInput<0)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
        else
        {
         rb.linearVelocity = new Vector2(0, rb.linearVelocity.y *.7f);
        
        }
        if (player.IsGroundDeteced())
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
