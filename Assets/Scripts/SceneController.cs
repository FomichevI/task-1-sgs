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
        LoadWithLoadingScene("GalleryScene");
    }
    public void LoadViewScene(string currentUrl)
    {
        GameData.Instance.CurrentUrlPath = currentUrl;
        LoadWithLoadingScene("ViewScene");
    }
    public void LoadMenuScene()
    {
        LoadWithLoadingScene("MenuScene");
    }
    private void LoadWithLoadingScene(string sceneName)
    {
        GameData.Instance.SceneToLoad = sceneName;
        SceneManager.LoadScene("LoadingScene");
        Screen.orientation = ScreenOrientation.Portrait;
        if (sceneName == "ViewScene")
            Screen.orientation = ScreenOrientation.AutoRotation;
    }
    public void BackToPreviousScene()
    {
        int curIndex = SceneManager.GetActiveScene().buildIndex;
        if (curIndex == 2)
            LoadMenuScene();
        else if (curIndex == 0)
            Application.Quit();
        else if (curIndex == 3)
            LoadGalleryScene();
    }
}
