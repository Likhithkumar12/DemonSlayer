using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundState : PlayerState
{
    public PlayerGroundState(PllayerStateMachine _pllayerStateMachine, Player _player, string _animboolname) : base(_pllayerStateMachine, _player, _animboolname)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            pllayerStateMachine.Changestate(player.primaryattackState);
        }

        if (Input.GetKeyDown(KeyCode.Space) && player.iusgrounded())
        {
            pllayerStateMachine.Changestate(player.pLayerJumpState);
        }
        if (!player.iusgrounded())
        {
            pllayerStateMachine.Changestate(player.playerAirState);
        }

    }
}

