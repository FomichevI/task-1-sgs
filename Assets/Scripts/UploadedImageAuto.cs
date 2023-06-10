using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class UploadedImageAuto : UploadedImage
{
    private SpriteRenderer _spriteRenderer;
    private bool _isLoaded = false;

    protected override void Awake()
    {
        base.Awake();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _countOfColumn = GameData.Instance.CountOfColumn;
    }
    protected override void Start()
    {       }

    /// <summary>
    /// При именовании изображений по порядку, находящихся по одному адресу
    /// </summary>
    /// <param name="urlFolder">Общая часть URL</param>
    public void SetUrl(string urlFolder, int sequenceNumber)
    {
        _url = urlFolder + sequenceNumber + ".jpg";
    }

    private void Update()
    {
        if(_spriteRenderer.isVisible && !_isLoaded)
        {
            LoadImage();
            _isLoaded = true;
        }
    }

    public void OpenImage() //Открытие текущего изображения в новой сцене
    {
        SceneController.Instance?.LoadViewScene(_url);
    }

}
