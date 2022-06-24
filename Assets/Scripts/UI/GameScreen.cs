using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class GameScreen : GenericMenu
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private GameObject _upperLine;
    [SerializeField] private GameObject _lowerLine;
    [SerializeField] private List<GameObject> _slotPrefabs;
    [SerializeField] private int _minElementNum;
    [SerializeField] private int _defaultBet;

    private List<GameObject> _upperLineElements = new List<GameObject>();
    private List<GameObject> _lowerLineElements = new List<GameObject>();

    private void Start()
    {
        _scoreText.text = _defaultBet.ToString();
        GenerateSlots();
    }

    private void GenerateSlots()
    {
        for (var i = 0; i < _minElementNum; i++)
        {
            var upperSlotElement = Instantiate(_slotPrefabs[Random.Range(0, _slotPrefabs.Count - 1)], _upperLine.transform);
            _upperLineElements.Add(upperSlotElement);
            var lowerSlotElement = Instantiate(_slotPrefabs[Random.Range(0, _slotPrefabs.Count - 1)], _lowerLine.transform);
            _lowerLineElements.Add(lowerSlotElement);
        }
    }

    private void ClearLines()
    {
        for (var i = _upperLineElements.Count - 1; i >= 0; i--)
        {
            Destroy(_upperLineElements[i]);
            _upperLineElements.RemoveAt(i);
        }
        for (var i = _lowerLineElements.Count - 1; i >= 0; i--)
        {
            Destroy(_lowerLineElements[i]);
            _lowerLineElements.RemoveAt(i);
        }
    }

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
        ClearLines();
        GenerateSlots();
    }

    private void OnExitButtonClick()
    {
        RemoveAllListeners();
        Application.Quit();
    }
}
