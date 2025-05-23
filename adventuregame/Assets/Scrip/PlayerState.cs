using UnityEngine;

public class PlayerState 
{
   protected Rigidbody2D rb;
   protected float xInput;
   
   protected float yInput;
   private string animBoolName;
   protected float stateTimer;
   protected bool triggerCalled;
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
   triggerCalled = false;
}

 public virtual void Update()
   {
      stateTimer -= Time.deltaTime;
      xInput = Input.GetAxisRaw("Horizontal");
      yInput = Input.GetAxisRaw("Vertical");
      player.anim.SetFloat("yVelocity", rb.linearVelocity.y);
   }

public virtual void Exit()
{
   player.anim.SetBool(animBoolName, false); 
}
public virtual void AnimationFinishTrigger()
{
   
   triggerCalled = true;
   
}
}