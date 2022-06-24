using UnityEngine;
using UnityEngine.UI;

public class StartScreen : GenericMenu
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
        MainMenu.Instance.ShowPolicyScreen();
    }

    private void OnExitButtonClick()
    {
        RemoveAllListeners();
        Application.Quit();
    }
}
