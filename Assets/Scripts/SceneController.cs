using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void LoadGalleryScene()
    {
        LoadWithLoadingScene(1);
        Screen.orientation = ScreenOrientation.Portrait;
    }
    public void LoadViewScene(string currentUrl)
    {
        GameData.Instance.CurrentUrlPath = currentUrl;
        LoadWithLoadingScene(2);
        Screen.orientation = ScreenOrientation.Portrait;
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
    public void LoadMenuScene()
    {
        LoadWithLoadingScene(0);
        Screen.orientation = ScreenOrientation.Portrait;
    }
    private void LoadWithLoadingScene(int index)
    {
        SceneManager.LoadScene(index);

    }
    public void BackToPreviousScene()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
            LoadWithLoadingScene(SceneManager.GetActiveScene().buildIndex -1);
        else
            Application.Quit();
    }
}
