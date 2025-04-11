using UnityEngine;


public class Playeridle : PlayerGroundState
{
    public Playeridle(PllayerStateMachine _playerstatemachine, Player _player, string _animboolname) : base(_playerstatemachine, _player, _animboolname)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.rigidbody2D.linearVelocity = new Vector2(0, 0);
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
       if(xinput!=0)
        {
            pllayerStateMachine.Changestate(player.Playermove);

        }
    }
}
