using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameConfig gameConfig;

    [SerializeField] CameraService cameraService;

    public StateMaschine StateMaschine { get; private set; }

    void Start()
    {
        var startState = new GameLoadingState(gameConfig);
        StateMaschine = new StateMaschine(this);
        StateMaschine.Swich(startState);

        StartServices();
    }

    private void Update()
    {
        StateMaschine?.Update();
    }

    private void StartServices()
    {
        cameraService.Run();
    }

}
