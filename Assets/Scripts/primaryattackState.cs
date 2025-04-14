using UnityEngine;

public class PrimaryattackState : PlayerState
{
    protected int combocounter;
    protected float lasttimeattacked;
    protected float combowindow = 2;

    public PrimaryattackState(PllayerStateMachine _pllayerStateMachine, Player _player, string _animboolname) : base(_pllayerStateMachine, _player, _animboolname)
    {
    }
    public override void Enter()
    {
        base.Enter();

        combocounter++;
        if (combocounter > 2 || lasttimeattacked + combowindow <= Time.time)
        {
            combocounter = 0;
        }
        player.Animator.SetInteger("ComboCounter", combocounter);
        player.Animator.speed = 1.1f;
        statetimer = 0.1f;
    
    }
    public override void Update()
    {
        base.Update();
        if (statetimer < 0)
        {
            player.rigidbody2D.linearVelocity = new Vector2(0, 0);
        }
        if (triggercalled)
            {
                pllayerStateMachine.Changestate(player.Playeridle);
            }
    }
    public override void Exit()
    {
        base.Exit();
        lasttimeattacked = Time.time;
        player.Animator.speed = 1f;
    }
}
