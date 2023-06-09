using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewScaling : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _gridLayout;
    [SerializeField] private int _spacings = 20;
    [Header("Максимальное соотношение W к H")]
    [SerializeField] private float _hieghtScale = 1.0f;
    [SerializeField] private int _numberOfColumns = 2;

    private void Start()
    {
        int screenWidht = Screen.width;
        float widht = (float)(screenWidht - 3 * _spacings) / _numberOfColumns;
        _gridLayout.cellSize = new Vector2(widht, (float)widht/ _hieghtScale);
    }

}
