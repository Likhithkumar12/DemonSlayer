using UnityEngine;

public class PlayerWallJUmpstate : PlayerState
{
    public PlayerWallJUmpstate(PllayerStateMachine _pllayerStateMachine, Player _player, string _animboolname) : base(_pllayerStateMachine, _player, _animboolname)
    {
    }
    public override void Enter()
    {
        base.Enter();
        statetimer = 1f;
        player.Setvelocity(.5f*-player.facinngdir, player.jumpforce);
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        if (statetimer < 0)
        {
            pllayerStateMachine.Changestate(player.playerAirState);
        }
        if (player.iusgrounded())
        {
            pllayerStateMachine.Changestate(player.Playeridle);
        }
    }
}
