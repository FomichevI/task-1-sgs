using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewScaling : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _gridLayout;

    private void Awake()
    {
        int screenWidht = Screen.width;
        float widht = (float)(screenWidht - (GameData.Instance.CountOfColumn + 1) * GameData.Instance.Offset) / GameData.Instance.CountOfColumn;
        _gridLayout.cellSize = new Vector2(widht, (float)widht/ GameData.Instance.HieghtScale);
    }

}
