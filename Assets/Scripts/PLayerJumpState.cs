using UnityEngine;

public class PLayerJumpState : PlayerState
{
    public PLayerJumpState(PllayerStateMachine _pllayerStateMachine, Player _player, string _animboolname) : base(_pllayerStateMachine, _player, _animboolname)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.rigidbody2D.linearVelocity = new Vector2(player.rigidbody2D.linearVelocity.x, player.jumpforce);
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        if (player.rigidbody2D.linearVelocity.y < 0)
        {
            pllayerStateMachine.Changestate(player.playerAirState);
        }

    }
   
}