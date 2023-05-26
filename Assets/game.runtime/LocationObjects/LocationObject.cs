using UnityEngine;

public class LocationObject : MonoBehaviour
{
    [SerializeField] private GameObject selectModeView;
    [SerializeField] private bool isObstacle;
    private Cell _inCell;

    public bool IsSelected { get; private set; }
    public bool IsObstacle => isObstacle;

    public virtual void Select()
    {
        IsSelected = true;
        selectModeView.SetActive(true);
    }

    public virtual void UnSelect()
    {
        IsSelected = false;
        selectModeView.SetActive(false);
    }


    public void SetPosition(Cell cell)
    {
        if (_inCell != null) _inCell.RemoveFromCell();

        _inCell = cell;
        var pos = cell.position2d;
        transform.position = new Vector3(pos.x, 0, pos.y);
        _inCell.PlaceToCell(this);
    }

}