using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(GameConfig), menuName = "Game/Configuration/" + nameof(GameConfig))]
public class GameConfig : BaseConfig
{
    [Header("Карта")]
    [SerializeField] private LevelConfig levelConfig;

    [Header("Интерфейс")]
    [SerializeField] private UIConfig uiConfig;
    
    public UIConfig UIConfig => uiConfig;
    
    public LevelConfig LevelConfig => levelConfig;

}


[Serializable]
public class LevelConfig
{
    [SerializeField] private Level levelPref;
    [SerializeField] private Vector2Int mapSize = new Vector2Int(10,10);

    [SerializeField] private Cell cellPref;
    [SerializeField] [Range(1,3)] private int cellSize = 1;

    [Header("Игрок A")]
    [SerializeField] private PlayerConfig playerAConfig;

    [Header("Игрок B")]
    [SerializeField] private PlayerConfig playerBConfig;
    
    [Header("Препятствие")]
    [SerializeField] private ObstacleConfig obstacleConfig;

    public Level LevelPref => levelPref;
    public Vector2Int MapSize => mapSize;

    public Cell CellPref => cellPref;
    public int CellSize => cellSize;

    public PlayerConfig PlayerAConfig => playerAConfig;
    public PlayerConfig PlayerBConfig => playerBConfig;
    public ObstacleConfig ObstacleConfig => obstacleConfig;
}


[Serializable]
public class PlayerConfig
{
    [SerializeField] private Player playerPref;
    [SerializeField] private Vector2Int position;

    public Player PlayerPref => playerPref;
    public Vector2Int Position => position;
}

[Serializable]
public class ObstacleConfig
{
    [SerializeField] private Obstacle obstaclePref;

    public Obstacle ObstaclePref => obstaclePref;
}


[Serializable]
public class UIConfig
{
    [SerializeField] private LoadingView loadingViewPref;
    [SerializeField] private EditModeView editModeViewPref;
    
    public LoadingView LoadingViewPref => loadingViewPref;
    public EditModeView EditModeViewPref => editModeViewPref;
}
