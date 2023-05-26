using System;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Action<Cell> OnCellMouseEnter;
    public Action<Cell> OnCellMouseClick;

    public Player PlayerA => _data.playerA;
    public Player PlayerB => _data.playerB;

    private LevelConfig _config;
    private LevelData _data;

    public void Construct(LevelConfig config)
    {
        _config = config;
        _data= new LevelData();
        CreateGrid();
        CreatePlayers();
        CreateObstacles();
    }

    private void CreateGrid()
    {
        var sizeX = _config.MapSize.x;
        var sizeY = _config.MapSize.y;

        _data.cells = new Cell[sizeX,sizeY];

        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                var cell = Instantiate(_config.CellPref, transform);
                cell.Construct(OnCellMouseEnterInternal, OnCellMouseClickInternal);
                cell.transform.localScale = new Vector3(_config.CellSize, cell.transform.localScale.y, _config.CellSize);
                cell.transform.localScale = cell.transform.localScale * 0.95f;
                cell.transform.position = new Vector3(x * _config.CellSize, 0, y * _config.CellSize);
                _data.cells[x, y] = cell;
            }
        }
    }

    private void CreatePlayers()
    {
        _data.playerA = Instantiate(_config.PlayerAConfig.PlayerPref, transform);
        var cellA = GetCell(_config.PlayerAConfig.Position);
        _data.playerA.SetPosition(cellA);

        _data.playerB = Instantiate(_config.PlayerBConfig.PlayerPref, transform);
        var cellB = GetCell(_config.PlayerBConfig.Position);
        _data.playerB.SetPosition(cellB);
    }

    private void CreateObstacles()
    {
        _data.obstacles = new List<Obstacle>();
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
        return _data.cells[pos.x, pos.y];
    }

    public void CreateObstacle(Cell cell)
    {
        var obstacle = Instantiate(_config.ObstacleConfig.ObstaclePref, transform);
        obstacle.SetPosition(cell);

        _data.obstacles.Add(obstacle);
        _data.cells[cell.position2d.x, cell.position2d.y].PlaceToCell(obstacle);
    }

    public void RemoveObstacle(Cell cell)
    {
        var obstacle = (Obstacle)cell.placedObject;
        _data.obstacles.Remove(obstacle);
        _data.cells[cell.position2d.x, cell.position2d.y].PlaceToCell(null);
        Destroy(obstacle.gameObject);
    }

}
