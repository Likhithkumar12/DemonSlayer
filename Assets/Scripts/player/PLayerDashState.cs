using UnityEngine;

public class PLayerDashState : PlayerState
{
    public PLayerDashState(PllayerStateMachine _pllayerStateMachine, Player _player, string _animboolname) : base(_pllayerStateMachine, _player, _animboolname)
    {
    }
    public override void Enter()
    {
        base.Enter();
        statetimer =player.dashdurtation;
    }
    public override void Update()
    {
        base.Update();
        if(player.iswall() && !player.iusgrounded())
        {
            pllayerStateMachine.Changestate(player.playerWallSlideStatw);
        }
        player.Setvelocity(player.dashspeed * player.facinngdir, player.rigidbody2D.linearVelocity.y);
        if (statetimer < 0)
        {
            pllayerStateMachine.Changestate(player.Playeridle);
        }

    }
    public override void Exit()
    {
        base.Exit();
        player.Setvelocity(0, player.rigidbody2D.linearVelocity.y);
    }
}
