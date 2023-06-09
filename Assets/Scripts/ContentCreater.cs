using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentCreater : MonoBehaviour
{
    [SerializeField] private string _urlFolder;
    [SerializeField] private int _countOfImages = 66;
    [SerializeField] private Transform _contentTransform;
    [SerializeField] private GameObject _uploadedImagePrefab;

    void Start()
    {
        for (int i = 1; i<= _countOfImages; i++)
        {
            GameObject upImage = Instantiate(_uploadedImagePrefab, _contentTransform);
            upImage.transform.localScale = Vector3.one;
            upImage.GetComponent<UploadedImage>()?.SetUrl(_urlFolder, i);
        }
    }
}
