using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameScreen : GenericMenu
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private TMP_Text _scoreText;

    protected override void AddAllListeners()
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    protected override void RemoveAllListeners()
    {
        _playButton.onClick.RemoveAllListeners();
        _exitButton.onClick.RemoveAllListeners();
    }

    private void OnPlayButtonClick()
    {
        
    }

    private void OnExitButtonClick()
    {
        RemoveAllListeners();
        Application.Quit();
    }
}
