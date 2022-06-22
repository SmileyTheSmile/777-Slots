using UnityEngine;
using UnityEngine.UI;

public class PolicyScreen : GenericMenu
{
    [SerializeField] private Button _termsButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Slider _acceptSlider;

    protected override void AddAllListeners()
    {
        _termsButton.onClick.AddListener(OnTermsButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _acceptSlider.onValueChanged.AddListener(OnAcceptClick);
    }

    protected override void RemoveAllListeners()
    {
        _termsButton.onClick.RemoveAllListeners();
        _exitButton.onClick.RemoveAllListeners();
        _acceptSlider.onValueChanged.RemoveAllListeners();
    }

    private void OnTermsButtonClick()
    {
        UIManager.Instance.ShowTermsScreen();
    }

    private void OnAcceptClick(float value)
    {
        UIManager.Instance.LoadMenu();
    }

    private void OnExitButtonClick()
    {
        RemoveAllListeners();
        Application.Quit();
    }
}