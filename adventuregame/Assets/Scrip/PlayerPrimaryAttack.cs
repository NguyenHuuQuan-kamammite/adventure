using UnityEngine;

public class PlayerPrimaryAttack : PlayerState
{
    private int comboCounter;
    private float lastTimeAttack;
    private float comboWindow = 2f;
    public PlayerPrimaryAttack(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
        
    }
    public override void Enter()
    {
        base.Enter();
        if(comboCounter >2 || Time.time >= lastTimeAttack + comboWindow)
          comboCounter = 0;
        
       player.anim.SetInteger("ComboCounter", comboCounter);
       
        
    }
    public override void Update()
    {
        base.Update();
           if (triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
    public override void Exit()
    {
        base.Exit();
        comboCounter++;
        lastTimeAttack = Time.time;
        
    }   
}

