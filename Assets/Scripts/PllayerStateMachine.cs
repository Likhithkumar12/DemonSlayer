public class PllayerStateMachine
{
    public PlayerState Currentstate { get; private set; }

    public void Initiallize(PlayerState startstate)
    {
        Currentstate = startstate;
        Currentstate.Enter();
    }
    public void Changestate(PlayerState newstate)
    {
        Currentstate.Exit();
        Currentstate = newstate;
        Currentstate.Enter();
    }


}
