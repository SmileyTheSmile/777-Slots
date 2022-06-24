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
    [SerializeField] private int _betMultiplier;
    [SerializeField] private float _shiftDelayUpper;
    [SerializeField] private float _shiftDelayLower;

    private List<GameObject> _upperLineElements = new List<GameObject>();
    private List<GameObject> _lowerLineElements = new List<GameObject>();

    private float _lastShiftTimeUpper;
    private float _lastShiftTimeLower;
    private int _currentBet;
    private bool _spinning;

    private void Start()
    {
        _currentBet = _defaultBet;
        _scoreText.text = _currentBet.ToString();
        _spinning = false;

        ClearLines();
        GenerateSlots();
    }

    private void Update()
    {
        if (!_spinning)
            return;
        
        if (_lastShiftTimeUpper + _shiftDelayUpper <= Time.time)
        {
            _lastShiftTimeUpper = Time.time;
            ShiftLineElements(_upperLineElements, _upperLine);
        }

        if (_lastShiftTimeLower + _shiftDelayLower <= Time.time)
        {
            _lastShiftTimeLower = Time.time;
            ShiftLineElements(_lowerLineElements, _lowerLine);
        }
    }

    private void ClearLines()
    {
        for (int i = _upperLineElements.Count - 1; i >= 0; i--)
        {
            Destroy(_upperLineElements[i]);
            _upperLineElements.RemoveAt(i);
        }
        for (int i = _lowerLineElements.Count - 1; i >= 0; i--)
        {
            Destroy(_lowerLineElements[i]);
            _lowerLineElements.RemoveAt(i);
        }
    }

    private void ShiftLineElements(List<GameObject> list, GameObject line)
    {
        Destroy(list[0]);
        list.RemoveAt(0);

        GameObject newElement = Instantiate(_slotPrefabs[Random.Range(0, _slotPrefabs.Count - 1)], line.transform);
        list.Add(newElement);
    }

    private void GenerateSlots()
    {
        for (int i = 0; i < _minElementNum; i++)
        {
            GameObject upperSlotElement = Instantiate(_slotPrefabs[Random.Range(0, _slotPrefabs.Count - 1)], _upperLine.transform);
            _upperLineElements.Add(upperSlotElement);
            GameObject lowerSlotElement = Instantiate(_slotPrefabs[Random.Range(0, _slotPrefabs.Count - 1)], _lowerLine.transform);
            _lowerLineElements.Add(lowerSlotElement);
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
        if (!_spinning)
        {
            _spinning = true;

            _lastShiftTimeUpper = Time.time;
            _lastShiftTimeLower = Time.time;
        }
        else
        {
            _spinning = false;

            if (_upperLineElements[1].name == _lowerLineElements[1].name)
            {
                _currentBet *= _betMultiplier;
                _scoreText.text = _currentBet.ToString();
            }
        }
    }

    private void OnExitButtonClick()
    {
        RemoveAllListeners();
        Application.Quit();
    }
}
