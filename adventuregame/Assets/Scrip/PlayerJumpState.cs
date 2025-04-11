using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {

    }
        public override void Enter()
    {
        base.Enter();
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, player.jumpForce);
        
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
       base.Update(); 
           
            if (rb.linearVelocity.y < 0)
            {
                stateMachine.ChangeState(player.airState);
            }
  
    }
}


