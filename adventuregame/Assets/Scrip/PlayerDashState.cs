using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
        
    }
    public override void Enter()     
    {
        base.Enter();

        stateTimer = player.dashDuration;
       
    }
    public override void Exit()
    {
        base.Exit();
        player.SetVelocity(0f, rb.linearVelocity.y);
     
    }
    public override void Update()
    {
        base.Update();
        player.SetVelocity(player.dashSpeed * player.dashDir, rb.linearVelocity.y);
        if (stateTimer <= 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
        if(!player.IsGroundDeteced() && player.IsWallDetected())
        {
            stateMachine.ChangeState(player.wallSlideState);
        }


    }


}
