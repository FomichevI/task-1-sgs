using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UploadedImage : MonoBehaviour
{
    [Header("Количество столбцов с изображениями")]
    protected int _countOfColumn = 1; //1 для 1 изображения и GameData.Instance.CountOfColumn для сетки изображений
    protected Image _image;
    protected string _url;

    protected virtual void Awake()
    {
        _image = GetComponent<Image>();
    }

    protected virtual void Start()
    {
        _url = GameData.Instance.CurrentUrlPath;
        LoadImage();
    }

    public void SetUrl(string fullUrl)
    {
        _url = fullUrl;
    }

    public void LoadImage()
    {
        StartCoroutine(SetImage());
    }

    protected void SetImageScale(Texture tex) //На случай, если изображение не квадратное
    {
        float x = tex.width;
        float y = tex.height;
        float currentX = (float)(Screen.width - (_countOfColumn + 1) * GameData.Instance.Offset) / _countOfColumn;
        float scaleX = x / currentX;
        float currentY = y / scaleX;
        Vector2 imageSize = new Vector2(currentX, currentY);
        _image.rectTransform.sizeDelta = imageSize;
    }

    IEnumerator SetImage()
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(_url);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.DataProcessingError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
            SetImageScale(tex);
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
            _image.overrideSprite = sprite;
        }
        request.Dispose();
    }
}
