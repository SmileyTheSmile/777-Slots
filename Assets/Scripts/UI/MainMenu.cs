using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;

    [SerializeField] private GameObject _acceptScreen;
    [SerializeField] private GameObject _termsScreen;
    [SerializeField] private GameObject _startScreen;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        ShowMenuScreen();
    }

    public void LoadMenu()
    {
        StartCoroutine(LoadSceneCoroutine("Menu"));
        ShowPolicyScreen();
    }

    public void LoadGame()
    {
        StartCoroutine(LoadSceneCoroutine("Game"));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        var asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncOperation.isDone)
            yield return null;
    }

    public void ShowMenuScreen()
    {
        HideAllScreens();
        _startScreen.SetActive(true);
    }

    public void ShowPolicyScreen()
    {
        HideAllScreens();
        _acceptScreen.SetActive(true);
    }

    public void ShowTermsScreen()
    {
        HideAllScreens();
        _termsScreen.SetActive(true);
    }

    public void HideAllScreens()
    {
        _acceptScreen.SetActive(false);
        _termsScreen.SetActive(false);
        _startScreen.SetActive(false);
    }
}