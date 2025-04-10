using UnityEngine;

public class PlayerMoveState : PlayerState
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
        if (Input.GetKeyDown(KeyCode.N))
        {
            stateMachine.ChangeState(player.idleState);
        }
        
    }
    public override void Exit()
    {
        base.Exit();
    }   
}

