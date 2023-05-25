using UnityEngine;

public class LocationObject : MonoBehaviour
{
    [SerializeField] private GameObject selectModeView;
    public bool IsSelected { get; private set; }

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

}
