using System.Collections;
using UnityEngine;

public class GameLoadingState : State
{
    private GameConfig _gameConfig;
    private LoadingView _view;

    // Конструктор, для простого di
    public GameLoadingState(GameConfig gameConfig)
    {
        _gameConfig = gameConfig;
    }

    public override void OnEnter()
    {
        Debug.Log("Загрузка");
        _view = Object.Instantiate(_gameConfig.UIConfig.LoadingViewPref);
        Game.StartCoroutine(LoadGame());
    }

    public override void OnExit()
    {
        Object.Destroy(_view.gameObject);
    }

    private IEnumerator LoadGame()
    {
        // симуляция загрузки
        var level = LoadLevel();

        //..
        yield return new WaitForSeconds(2);
        StateMaschine.Swich(new GameEditState(_gameConfig, level));
    }

    private Level LoadLevel()
    {
        var level = Object.Instantiate(_gameConfig.LevelConfig.LevelPref);
        level.Construct(_gameConfig.LevelConfig);
        return level;
    }
}
