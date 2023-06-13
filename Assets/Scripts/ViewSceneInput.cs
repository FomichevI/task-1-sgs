using UnityEngine;

public class ViewSceneInput : MonoBehaviour //В дальнейшем можно расшарить для инпута типа "зум" изображения и прочего
{
    public void CloseScene()
    {
        SceneController.Instance.BackToPreviousScene();
    }
}
