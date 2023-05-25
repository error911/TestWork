using UnityEngine;

public class GameEditState : State
{
    private EditModeView _view;
    private GameConfig _gameConfig;
    private Level _level;
    private Player _selectedPlayer;

    // Конструктор, для простого di
    public GameEditState(GameConfig gameConfig, Level level)
    {
        _gameConfig = gameConfig;
        _level = level;
    }

    public override void OnEnter()
    {
        Debug.Log("Режим редактирования");

        _level.OnCellMouseEnter += OnCellEnter;
        _level.OnCellMouseClick += OnCellClick;

        _view = Object.Instantiate(_gameConfig.UIConfig.EditModeViewPref);
        _view.Construct(OnPlay, OnEditPlayerA, OnEditPlayerB, OnEditObstacles);
        OnEditPlayerA();
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

    private void OnPlay()
    {
        
    }

    private void OnEditPlayerA()
    {
        _selectedPlayer?.UnSelect();

        _selectedPlayer = _level.PlayerA;
        _selectedPlayer.Select();
    }

    private void OnEditPlayerB()
    {
        _selectedPlayer?.UnSelect();

        _selectedPlayer = _level.PlayerB;
        _selectedPlayer.Select();
    }

    private void OnEditObstacles()
    {

    }


    private void OnCellEnter(Cell cell)
    {
        
    }

    private void OnCellClick(Cell cell)
    {
        Debug.Log($"{cell.transform.position.x}, {cell.transform.position.z}");
        if (_selectedPlayer == null) return;
        if (cell.IsEmpty == false)
        {
            Debug.Log($"Занята {cell.position2d}, {cell.IsEmpty}");
            return; }

        _selectedPlayer.SetPosition(cell);
    }


}
