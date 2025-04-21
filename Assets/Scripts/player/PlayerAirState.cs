using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(PllayerStateMachine _pllayerStateMachine, Player _player, string _animboolname) : base(_pllayerStateMachine, _player, _animboolname)
    {
    }
    public override void Update()
    {
        base.Update();
        if (player.iusgrounded())
        {
            pllayerStateMachine.Changestate(player.Playeridle);
        }

        if (xinput != 0)
        {
            player.Setvelocity(player.movespeed * 0.1f * xinput, player.rigidbody2D.linearVelocity.y);
        }
        if(player.iswall())
        {
            pllayerStateMachine.Changestate(player.playerWallSlideStatw);
        }
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Exit()
    {
        base.Exit();
        player.Setvelocity(0, player.rigidbody2D.linearVelocity.y);
    }
}
