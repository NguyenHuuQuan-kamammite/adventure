using UnityEngine;

public class PlayerGroundState : PlayerState
{
    public PlayerGroundState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
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
        if(Input.GetKeyDown(KeyCode.Mouse0))
            stateMachine.ChangeState(player.primaryAttack);

      if (!player.IsGroundDeteced() )
       {
           stateMachine.ChangeState(player.airState);
       }
      
       if(Input.GetKeyDown(KeyCode.Space) && player.IsGroundDeteced())
       {
           stateMachine.ChangeState(player.jumpState);
       }
    }
}
