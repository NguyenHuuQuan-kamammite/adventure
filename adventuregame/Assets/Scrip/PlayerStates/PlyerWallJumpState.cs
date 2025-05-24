using System.Globalization;
using UnityEngine;

public class PlyerWallJumpState : PlayerState
{
    public PlyerWallJumpState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        stateTimer = .4f;
        player.SetVelocity(5f * -player.isFacingDir, player.jumpForce);
    }
    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer <= 0)
        {
            stateMachine.ChangeState(player.airState);
        }
        if (player.IsGroundDeteced())
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
   

