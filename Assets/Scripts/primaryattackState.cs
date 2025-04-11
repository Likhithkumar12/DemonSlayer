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
    
    }
    public override void Update()
    {
        base.Update();
        if (triggercalled)
        {
            pllayerStateMachine.Changestate(player.Playeridle);
        }
    }
    public override void Exit()
    {
        base.Exit();
        lasttimeattacked = Time.time;
    }
}
