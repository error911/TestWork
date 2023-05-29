using UnityEngine;

public class GameBattleState : State
{
    private BattleModeView _view;
    private GameConfig _gameConfig;
    private Level _level;
    private Player _selectedPlayer;

    // Конструктор, для простого di
    public GameBattleState(GameConfig gameConfig, Level level)
    {
        _gameConfig = gameConfig;
        _level = level;
    }

    #region State Abstract release
    public override void OnEnter()
    {
        Debug.Log("Режим боя");

        _level.OnCellMouseEnter += OnCellEnter;
        _level.OnCellMouseClick += OnCellClick;

        _view = Object.Instantiate(_gameConfig.UIConfig.BattleModeViewPref);
        _view.Construct(OnNextPlayer, OnEditor);

        OnNextPlayer();
    }

    public override void OnExit()
    {
        _level.OnCellMouseEnter -= OnCellEnter;
        _level.OnCellMouseClick -= OnCellClick;
        Object.Destroy(_view.gameObject);
    }

    public override void OnUpdate()
    {
        
    }

    #endregion


    private void OnNextPlayer()
    {
        if (_selectedPlayer == _level.PlayerB || _selectedPlayer == null)
        {
            _selectedPlayer = _level.PlayerA;
        }
        else if (_selectedPlayer == _level.PlayerA)
        {
            _selectedPlayer = _level.PlayerB;
        }
        _view.TextCaption.text = _selectedPlayer.PlayerName;
    }

    private void OnEditor()
    {
        StateMaschine.Swich(new GameEditState(_gameConfig, _level));
    }


    private void OnCellEnter(Cell cell)
    {
        
    }

    private void OnCellClick(Cell cell)
    {

    }

}
