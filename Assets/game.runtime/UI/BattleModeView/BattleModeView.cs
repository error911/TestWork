using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleModeView : MonoBehaviour
{
    [SerializeField] private Button btnNextPlayer;
    [SerializeField] private Button btnEditor;
    [SerializeField] private TMP_Text textCaption;

    public TMP_Text TextCaption => textCaption;

    private Action _onNextPlayer, _onEditor;

    public void Construct(Action onNextPlayer, Action onEditor)
    {
        _onNextPlayer = onNextPlayer;
        _onEditor = onEditor;
        textCaption.text = string.Empty;
    }

    void Start()
    {
        btnNextPlayer.onClick.AddListener(() => OnButtonNextPlayer());
        btnEditor.onClick.AddListener(() => OnButtonEditor());
    }

    private void OnButtonNextPlayer()
    {
        _onNextPlayer?.Invoke();
    }
    private void OnButtonEditor()
    {
        _onEditor?.Invoke();
    }

}
