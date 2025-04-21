public class Playermove : PlayerGroundState
{
    public Playermove(PllayerStateMachine _playerstatemachine, Player _player, string _animboolname) : base(_playerstatemachine, _player, _animboolname)
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
        player.Setvelocity(xinput,player.rigidbody2D.linearVelocity.y);
         if (xinput == 0 || player.iswall())
        {
            pllayerStateMachine.Changestate(player.Playeridle);

        }
    }
}
