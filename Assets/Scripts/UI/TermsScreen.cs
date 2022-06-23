using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TermsScreen : GenericMenu
{
    [SerializeField] private TextAsset _termsText;
    [SerializeField] private TMP_Text _textObject;
    [SerializeField] private Button _backButton;

    private void Awake()
    {
        _textObject.SetText(_termsText.text);
    }

    protected override void AddAllListeners()
    {
        _backButton.onClick.AddListener(OnBackButtonClick);
    }

    protected override void RemoveAllListeners()
    {
        _backButton.onClick.RemoveAllListeners();
    }

    private void OnBackButtonClick()
    {
        UIManager.Instance.ShowPolicyScreen();
    }
}
