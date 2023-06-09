using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class UploadedImage : MonoBehaviour
{
    private Image _image;
    private string _url;
    private SpriteRenderer _spriteRenderer;
    private bool _isLoaded = false;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetUrl(string fullUrl)
    {
        _url = fullUrl;
    }
    /// <summary>
    /// При именовании изображений по порядку, находящихся по одному адресу
    /// </summary>
    /// <param name="urlFolder">Общая часть URL</param>
    public void SetUrl(string urlFolder, int sequenceNumber)
    {
        _url = urlFolder + sequenceNumber + ".jpg";
    }

    public void LoadImage()
    {
        StartCoroutine(SetImage());
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
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
            _image.overrideSprite = sprite;
        }
        request.Dispose();
    }

    private void Update()
    {
        if(_spriteRenderer.isVisible && !_isLoaded)
        {
            LoadImage();
            _isLoaded = true;
        }
    }

}
