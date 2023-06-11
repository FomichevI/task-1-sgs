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
    }
    public void LoadViewScene(string currentUrl)
    {
        GameData.Instance.CurrentUrlPath = currentUrl;
        LoadWithLoadingScene(2);
    }
    public void LoadMenuScene()
    {
        LoadWithLoadingScene(0);
    }
    private void LoadWithLoadingScene(int index)
    {
        GameData.Instance.SceneToLoad = index;
        SceneManager.LoadScene(3);
        Screen.orientation = ScreenOrientation.Portrait;
        if (index == 2)
            Screen.orientation = ScreenOrientation.AutoRotation;
    }
    public void BackToPreviousScene()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
            LoadWithLoadingScene(SceneManager.GetActiveScene().buildIndex - 1);
        else
            Application.Quit();
    }
}
