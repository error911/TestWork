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

    #region State Abstract release
    public override void OnEnter()
    {
        Debug.Log("Режим редактирования");

        _level.OnCellMouseEnter += OnCellEnter;
        _level.OnCellMouseClick += OnCellClick;

        _view = Object.Instantiate(_gameConfig.UIConfig.EditModeViewPref);
        _view.Construct(OnPlay, OnSwichEditPlayerA, OnSwichEditPlayerB, OnSwichEditObstacles);
        OnSwichEditPlayerA();
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


    private void OnPlay()
    {
        
    }

    private void OnSwichEditPlayerA()
    {
        _selectedPlayer?.UnSelect();
        _editObstacles = false;

        _selectedPlayer = _level.PlayerA;
        _selectedPlayer.Select();
    }

    private void OnSwichEditPlayerB()
    {
        _selectedPlayer?.UnSelect();
        _editObstacles = false;

        _selectedPlayer = _level.PlayerB;
        _selectedPlayer.Select();
    }

    private bool _editObstacles;
    private void OnSwichEditObstacles()
    {
        _selectedPlayer?.UnSelect();
        _editObstacles = true;
    }


    private void OnCellEnter(Cell cell)
    {
        
    }

    private void OnCellClick(Cell cell)
    {
        Debug.Log($"{cell.transform.position.x}, {cell.transform.position.z}");

        if (_editObstacles)
            EditObstacle(cell);
        else
            EditPlayer(cell);
    }

    private void EditObstacle(Cell cell)
    {
        if (!cell.IsEmpty && !cell.placedObject.IsObstacle) return;

        if (cell.IsEmpty)
            _level.CreateObstacle(cell);
        else
            _level.RemoveObstacle(cell);
    }

    private void EditPlayer(Cell cell)
    {
        if (_selectedPlayer == null) return;
        if (cell.IsEmpty == false)
        {
            Debug.Log($"Занята {cell.position2d}, {cell.IsEmpty}");
            return;
        }

        _selectedPlayer.SetPosition(cell);
    }


}
