using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        rb.linearVelocity = new Vector2(0,0);
        
    }
    public override void Update()
    {
        base.Update();
        if (xInput != 0)
        {
            
            stateMachine.ChangeState(player.moveState);
        }
        if(xInput == player.isFacingDir && player.IsWallDetected())
        {
            return;
            
        }
  
       
    }
    public override void Exit()
    {
        base.Exit();
    }   

}
