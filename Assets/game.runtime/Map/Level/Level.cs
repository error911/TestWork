using System;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Action<Cell> OnCellMouseEnter;
    public Action<Cell> OnCellMouseClick;

    public Player PlayerA => _playerA;
    public Player PlayerB => _playerB;

    private LevelConfig _config;
    private Cell[,] _cells;
    private Player _playerA;
    private Player _playerB;
    private List<Obstacle> _obstacles;

    public void Construct(LevelConfig config)
    {
        _config = config;
        CreateGrid();
        CreatePlayers();
        CreateObstacles();
    }

    private void CreateGrid()
    {
        var sizeX = _config.MapSize.x;
        var sizeY = _config.MapSize.y;

        _cells = new Cell[sizeX,sizeY];

        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                var cell = Instantiate(_config.CellPref, transform);
                cell.Construct(OnCellMouseEnterInternal, OnCellMouseClickInternal);
                cell.transform.localScale = new Vector3(_config.CellSize, cell.transform.localScale.y, _config.CellSize);
                cell.transform.localScale = cell.transform.localScale * 0.95f;
                cell.transform.position = new Vector3(x * _config.CellSize, 0, y * _config.CellSize);
                _cells[x, y] = cell;
            }
        }
    }

    private void CreatePlayers()
    {
        _playerA = Instantiate(_config.PlayerAConfig.PlayerPref, transform);
        var cellA = GetCell(_config.PlayerAConfig.Position);
        _playerA.SetPosition(cellA);

        _playerB = Instantiate(_config.PlayerBConfig.PlayerPref, transform);
        var cellB = GetCell(_config.PlayerBConfig.Position);
        _playerB.SetPosition(cellB);
    }

    private void CreateObstacles()
    {
        _obstacles = new List<Obstacle>();
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

    public void CreateObstacle(Cell cell)
    {
        var obstacle = Instantiate(_config.ObstacleConfig.ObstaclePref, transform);
        obstacle.SetPosition(cell);

        _obstacles.Add(obstacle);
        _cells[cell.position2d.x, cell.position2d.y].PlaceToCell(obstacle);
    }

    public void RemoveObstacle(Cell cell)
    {
        var obstacle = (Obstacle)cell.placedObject;
        _obstacles.Remove(obstacle);
        _cells[cell.position2d.x, cell.position2d.y].PlaceToCell(null);
        Destroy(obstacle.gameObject);
    }

}
