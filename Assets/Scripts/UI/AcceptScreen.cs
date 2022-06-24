using UnityEngine;
using UnityEngine.UI;

public class AcceptScreen : GenericMenu
{
    [SerializeField] private Button _termsButton;
    [SerializeField] private Button _backButton;
    [SerializeField] private Slider _acceptSlider;

    protected override void AddAllListeners()
    {
        _termsButton.onClick.AddListener(OnTermsButtonClick);
        _backButton.onClick.AddListener(OnBackButtonClick);
        _acceptSlider.onValueChanged.AddListener(OnAcceptSliderClick);
    }

    protected override void RemoveAllListeners()
    {
        _termsButton.onClick.RemoveAllListeners();
        _backButton.onClick.RemoveAllListeners();
        _acceptSlider.onValueChanged.RemoveAllListeners();
    }

    private void OnTermsButtonClick()
    {
        MainMenu.Instance.ShowTermsScreen();
    }

    private void OnAcceptSliderClick(float value)
    {
        MainMenu.Instance.LoadGame();
    }

    private void OnBackButtonClick()
    {
        MainMenu.Instance.ShowMenuScreen();
    }
}