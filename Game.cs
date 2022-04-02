using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    #region SIngleton:game
    public static Game Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    public bool _gameStop;
    [SerializeField] Text[] _allCoinsUiText;
    public int _coins;
    private void Start()
    {
        UpdateSetAllCoinsUIText();
        _gameStop = true;
    }

    public void UseCoin(int amount)
    {
        _coins -= amount;
    }

    public bool HasEnoughCoin(int amount)
    {
        return (_coins >= amount);
    }

    public void UpdateSetAllCoinsUIText()
    {
        for (int i = 0; i < _allCoinsUiText.Length; i++)
        {
            _allCoinsUiText[i].text = _coins.ToString();
        }
    }

}
