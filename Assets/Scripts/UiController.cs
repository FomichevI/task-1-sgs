using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void LoadGalleryScene()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadViewScene()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
