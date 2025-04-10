using UnityEngine;

public class PlayerState 
{
   protected PlayerStateMachine stateMachine;
    protected Player player;
    
    private string animBoolName;
 public PlayerState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }
 public virtual void Enter()
{
Debug.Log("Enter " + animBoolName);
}

 public virtual void Update()
{
Debug.Log("Im in " + animBoolName);     
}
public virtual void Exit()
{
   Debug.Log(" I Exit " + animBoolName); 
}
}
