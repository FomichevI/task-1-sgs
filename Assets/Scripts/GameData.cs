using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    public int CountOfColumn { get => _countOfColumn; }
    public int Offset { get => _offset; }
    public float HieghtScale { get => _hieghtScale; }
    public string UrlFolder { get => _urlFolder; }
    public int CountOfImages { get => _countOfImages; }
    public float LoadingTime { get => _loadingTime; }
    [HideInInspector] public string SceneToLoad;

    [HideInInspector] public string CurrentUrlPath;
    [SerializeField] private int _countOfColumn = 2;
    [SerializeField] private int _offset = 20;
    [Header("ћаксимальное соотношение W к H изображени€")]
    [SerializeField] private float _hieghtScale = 1.0f;
    [SerializeField] private string _urlFolder;
    [SerializeField] private int _countOfImages = 66;
    [SerializeField] private float _loadingTime = 2.5f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
