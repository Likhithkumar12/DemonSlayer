using UnityEngine;
public class PlayerState
{
    protected PllayerStateMachine pllayerStateMachine;
    protected Player player;
    protected string animboolname;
    protected float xinput;
    protected float statetimer;
    public PlayerState(PllayerStateMachine _pllayerStateMachine, Player _player, string _animboolname)
    {
        this.pllayerStateMachine = _pllayerStateMachine;
        this.player = _player;
        this.animboolname = _animboolname;
    }
    public virtual void Enter()
    {
        player.Animator.SetBool(animboolname, true);
    }
    public virtual void Update()
    {
        statetimer-= Time.deltaTime;
        xinput = Input.GetAxisRaw("Horizontal");
        player.Animator.SetFloat("yvelocity", player.rigidbody2D.linearVelocity.y);

    }
    public virtual void Exit()
    {
        player.Animator.SetBool(animboolname, false);

    }
 

}

