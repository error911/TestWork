using System;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Action<Cell> OnCellMouseEnter;
    public Action<Cell> OnCellMouseClick;

    public Player PlayerA => _playerA;
    public Player PlayerB => _playerB;
    
    private Cell[,] _cells;
    private Player _playerA;
    private Player _playerB;

    public void Construct(LevelConfig config)
    {
        CreateGrid(config);
        CreatePlayers(config);
    }

    private void CreateGrid(LevelConfig config)
    {
        var sizeX = config.MapSize.x;
        var sizeY = config.MapSize.y;

        _cells = new Cell[sizeX,sizeY];

        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                var cell = Instantiate(config.CellPref, transform);
                cell.Construct(OnCellMouseEnterInternal, OnCellMouseClickInternal);
                cell.transform.localScale = new Vector3(config.CellSize, cell.transform.localScale.y, config.CellSize);
                cell.transform.localScale = cell.transform.localScale * 0.95f;
                cell.transform.position = new Vector3(x * config.CellSize, 0, y * config.CellSize);
                _cells[x, y] = cell;
            }
        }
    }

    private void CreatePlayers(LevelConfig config)
    {
        _playerA = Instantiate(config.PlayerAConfig.PlayerPref, transform);
        var cellA = GetCell(config.PlayerAConfig.Position);
        _playerA.SetPosition(cellA);

        _playerB = Instantiate(config.PlayerBConfig.PlayerPref, transform);
        var cellB = GetCell(config.PlayerBConfig.Position);
        _playerB.SetPosition(cellB);
    }

    private void CreateObstacles()
    {

    }

    private void OnCellMouseEnterInternal(Cell cell)
    {
        OnCellMouseEnter?.Invoke(cell);
    }

    private void OnCellMouseClickInternal(Cell cell)
    {
        OnCellMouseClick?.Invoke(cell);
    }

    private Cell GetCell(Vector2Int pos)
    {
        return _cells[pos.x, pos.y];
    }

}
