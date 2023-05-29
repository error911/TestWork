using UnityEngine;

public class Player : LocationObject
{
    private PlayerConfig _config;

    public string PlayerName => _config.PlayerName;

    public void Construct(PlayerConfig config)
    {
        _config = config;
    }
}
