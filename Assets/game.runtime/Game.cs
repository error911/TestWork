using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameConfig gameConfig;

    public StateMaschine StateMaschine { get; private set; }

    void Start()
    {
        var startState = new GameLoadingState(gameConfig);
        StateMaschine = new StateMaschine(this);
        StateMaschine.Swich(startState);
    }

    private void Update()
    {
        StateMaschine?.Update();
    }

}
