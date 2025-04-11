using UnityEngine;

public class PlayerState 
{
   protected Rigidbody2D rb;
   protected float xInput;
   private string animBoolName;

   protected PlayerStateMachine stateMachine;
    protected Player player;
    
 public PlayerState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }
 public virtual void Enter()
{
   player.anim.SetBool(animBoolName, true);
   rb = player.rb;
}

 public virtual void Update()
   {
      xInput = Input.GetAxisRaw("Horizontal");
      player.anim.SetFloat("yVelocity", rb.linearVelocity.y);
   }

public virtual void Exit()
{
   player.anim.SetBool(animBoolName, false); 
}
}
