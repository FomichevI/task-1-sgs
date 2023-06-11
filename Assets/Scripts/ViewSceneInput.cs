using UnityEngine;

public class ViewSceneInput : MonoBehaviour
{
    public void CloseScene()
    {
        SceneController.Instance.BackToPreviousScene();
    }
}
