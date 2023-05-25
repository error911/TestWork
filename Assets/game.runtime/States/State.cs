using UnityEngine;

public abstract class State
{
    public StateMaschine StateMaschine => Game.StateMaschine;
    
    public Game Game { get; private set; }

    public abstract void OnEnter();
    public abstract void OnExit();
    public virtual void OnUpdate() {}

    public void Enter(Game game)
    {
        Game = game;
        Debug.Log($"State Enter: {GetType().Name}");
        OnEnter();
    }

    public void Exit()
    {
        Debug.Log($"State Exit: {GetType().Name}");
        OnExit();
    }

    public void Update()
    {
        OnUpdate();
    }

}