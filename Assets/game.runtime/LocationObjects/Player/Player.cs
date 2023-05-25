using UnityEngine;

public class Player : LocationObject
{
    //[SerializeField] private GameObject selectModel;

    //private bool _isSelected;
    private Cell _inCell;

    public void SetPosition(Cell cell)
    {
        if (_inCell != null) _inCell.RemovePlayer();

        _inCell = cell;
        var pos = cell.position2d;
        transform.position = new Vector3(pos.x, 0, pos.y);
        _inCell.SetPlayer(this);
    }

    /*public void Select(bool isSelected)
    {
        _isSelected = isSelected;
        selectModel.SetActive(isSelected);
    }*/


}
