using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private Fader _fader;
    [SerializeField] private GameObject _policyScreen;
    [SerializeField] private GameObject _termsScreen;
    //[SerializeField] private GameObject _menuScreen;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ShowPolicyScreen();
    }

    public void LoadMenu()
    {
        _fader.OnFadeOut += LoadMenuScene;
        _fader.FadeOut();
    }

    private void LoadMenuScene()
    {
        _fader.OnFadeOut -= LoadMenuScene;
        StartCoroutine(LoadSceneCoroutine("Menu"));
        LoadMenuScene();
    }

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        var asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncOperation.isDone)
            yield return null;

        _fader.FadeIn();
    }

    private void LoadPolicyScene()
    {
        _fader.OnFadeOut -= LoadPolicyScene;
        StartCoroutine(LoadSceneCoroutine("Policy"));
        ShowPolicyScreen();
    }

    public void ShowPolicyScreen()
    {
        HideAllScreens();
        _policyScreen.SetActive(true);
    }

    public void ShowTermsScreen()
    {
        HideAllScreens();
        _termsScreen.SetActive(true);
    }

    public void ShowMenuScreen()
    {
        HideAllScreens();
        //_menuScreen.SetActive(true);
    }

    public void HideAllScreens()
    {
        _policyScreen.SetActive(false);
        _termsScreen.SetActive(false);
        //_menuScreen.SetActive(false);
    }
}