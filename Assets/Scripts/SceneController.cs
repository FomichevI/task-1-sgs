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
        LoadWithLoadingScene(2);
    }
    public void LoadViewScene(string currentUrl)
    {
        GameData.Instance.CurrentUrlPath = currentUrl;
        LoadWithLoadingScene(3);
    }
    public void LoadMenuScene()
    {
        LoadWithLoadingScene(1);
    }
    private void LoadWithLoadingScene(int index)
    {
        GameData.Instance.SceneToLoad = index;
        SceneManager.LoadScene(0);
        Screen.orientation = ScreenOrientation.Portrait;
        if (index == 3)
            Screen.orientation = ScreenOrientation.AutoRotation;
    }
    public void BackToPreviousScene()
    {
        if (SceneManager.GetActiveScene().buildIndex > 1)
            LoadWithLoadingScene(SceneManager.GetActiveScene().buildIndex - 1);
        else
            Application.Quit();
    }
}
