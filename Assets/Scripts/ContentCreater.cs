using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentCreater : MonoBehaviour
{
    [SerializeField] private Transform _contentTransform;
    [SerializeField] private GameObject _uploadedImagePrefab;

    void Start()
    {
        for (int i = 1; i<= GameData.Instance.CountOfImages; i++)
        {
            GameObject upImage = Instantiate(_uploadedImagePrefab, _contentTransform);
            upImage.transform.localScale = Vector3.one;
            upImage.GetComponentInChildren<UploadedImageAuto>()?.SetUrl(GameData.Instance.UrlFolder, i);
        }
    }
}
