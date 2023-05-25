using System;
using UnityEngine;
using UnityEngine.UI;

public class EditModeView : MonoBehaviour
{
    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnPlayerA;
    [SerializeField] private Button btnPlayerB;
    [SerializeField] private Button btnObstacles;

    private Action _onPlay, _onPlayerA, _onPlayerB, _onObstacles;

    public void Construct(Action onPlay, Action onPlayerA, Action onPlayerB, Action onObstacles)
    {
        _onPlay = onPlay;
        _onPlayerA = onPlayerA;
        _onPlayerB = onPlayerB;
        _onObstacles = onObstacles;
    }

    void Start()
    {
        btnPlayerA.interactable = false;
        btnPlayerB.interactable = true;

        btnPlay.onClick.AddListener(() => OnButtonClickPlay());
        btnPlayerA.onClick.AddListener(() => OnButtonClickPlayerA());
        btnPlayerB.onClick.AddListener(() => OnButtonClickPlayerB());
        btnObstacles.onClick.AddListener(() => OnButtonClickObstacles());
    }

    private void OnButtonClickPlay()
    {
        _onPlay?.Invoke();
    }
    private void OnButtonClickPlayerA()
    {
        btnPlayerA.interactable = false;
        btnPlayerB.interactable = true;
        btnObstacles.interactable = true;

        _onPlayerA?.Invoke();
    }

    private void OnButtonClickPlayerB()
    {
        btnPlayerA.interactable = true;
        btnPlayerB.interactable = false;
        btnObstacles.interactable = true;

        _onPlayerB?.Invoke();
    }

    private void OnButtonClickObstacles()
    {
        btnPlayerA.interactable = true;
        btnPlayerB.interactable = true;
        btnObstacles.interactable = false;

        _onObstacles?.Invoke();
    }

}
