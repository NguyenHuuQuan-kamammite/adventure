using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        
    }
    public override void Update()
    {
        base.Update();
       
    }
    public override void Exit()
    {
        base.Exit();
    }   
}
