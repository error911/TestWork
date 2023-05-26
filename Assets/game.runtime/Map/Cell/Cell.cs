using System;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Vector2Int position2d => new Vector2Int((int)transform.position.x, (int)transform.position.z);

    public bool IsEmpty => placedObject == null;
//    private Player _player;
    public LocationObject placedObject { get; private set; }

    private Action<Cell> _onMouseEnter;
    private Action<Cell> _onMouseClick;

    public void Construct(Action<Cell> onMouseEnter, Action<Cell> onMouseClick)
    {
        _onMouseEnter = onMouseEnter;
        _onMouseClick = onMouseClick;
    }

    private void OnMouseEnter()
    {
        _onMouseEnter?.Invoke(this);
    }

    private void OnMouseDown()
    {
        _onMouseClick?.Invoke(this);
    }

    public void PlaceToCell(LocationObject locationElement)
    {
        placedObject = locationElement;
        //_player = player;
    }

    public void RemoveFromCell()
    {
        placedObject = null;
        //_player = null;
    }

}
