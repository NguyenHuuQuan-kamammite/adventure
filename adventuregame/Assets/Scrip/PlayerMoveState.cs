using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    public PlayerMoveState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
        
    }
        public override void Enter()
    {
        base.Enter();

         
        
    }
    public override void Update()
    {
        base.Update();
        
        player.SetVelocity( xInput* player.moveSpeed, rb.linearVelocity.y);
        if (xInput == 0 )
        {
            stateMachine.ChangeState(player.idleState);
        }
        
       
        
    }
    public override void Exit()
    {
        base.Exit();
    }   
}

