using UnityEngine;

public class PlayerWallSlideStatw : PlayerState
{
   
    public PlayerWallSlideStatw(PllayerStateMachine _pllayerStateMachine, Player _player, string _animboolname) : base(_pllayerStateMachine, _player, _animboolname)
    {
    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pllayerStateMachine.Changestate(player.playerWallJUmpstate);
            return;
        }

        if (xinput != 0 && player.facinngdir != xinput)
        {
            pllayerStateMachine.Changestate(player.Playeridle);

        }
        player.rigidbody2D.linearVelocity = new Vector2(0, player.rigidbody2D.linearVelocity.y * 0.8f);
        if (player.iusgrounded())
        {
            pllayerStateMachine.Changestate(player.Playeridle);
        }
       

    }

    public override void Exit()
    {
        base.Exit();

    }
}
