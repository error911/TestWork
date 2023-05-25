public class StateMaschine
{
    public State currentState {  get; private set; }

    private Game _game;

    public StateMaschine(Game game)
    {
        _game = game;
    }

    public void Swich(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter(_game);
    }

    public void Update()
    {
        currentState?.Update();
    }

}
