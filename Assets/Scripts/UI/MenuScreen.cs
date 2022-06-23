using UnityEngine;
using UnityEngine.UI;

public class MenuScreen : GenericMenu
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;

    protected override void AddAllListeners()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    protected override void RemoveAllListeners()
    {
        _startButton.onClick.RemoveAllListeners();
        _exitButton.onClick.RemoveAllListeners();
    }

    private void OnStartButtonClick()
    {
        UIManager.Instance.ShowPolicyScreen();
    }

    private void OnExitButtonClick()
    {
        RemoveAllListeners();
        Application.Quit();
    }
}
