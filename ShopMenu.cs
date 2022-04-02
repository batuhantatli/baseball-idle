using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    #region SIngleton:ShopMenu
    public static ShopMenu Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [System.Serializable] public class ShopItem
    {
        public Sprite Image;
        public int _price;
        public bool _isPurchased = false;
    }

    public List<ShopItem> _shopItemList;
    public int _boughtItemIntHolder;


    [SerializeField] Animator _noCoinsAnim;

    [SerializeField] GameObject _itemTemplate;
    GameObject _g;
    [SerializeField] Transform _shopScrollView;
    [SerializeField] GameObject _shopPanel;
    Button _buyButton;

    void Start()
    {
        int len = _shopItemList.Count;
        for (int i = 0; i < len; i++)
        {
            _g = Instantiate(_itemTemplate, _shopScrollView);
            _g.transform.GetChild(0).GetComponent<Image >().sprite = _shopItemList[i].Image;
            _g.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = _shopItemList[i]._price.ToString();
            _buyButton = _g.transform.GetChild(2).GetComponent<Button>();
            if (_shopItemList[i]._isPurchased)
            {
                DisableBuybutton();
            }
            
            _buyButton.AddEventListener(i, OnShopItemBtnClicked);
        }
    }
    void OnShopItemBtnClicked(int itemIndex)
    {
        _boughtItemIntHolder = itemIndex;
        if (Game.Instance.HasEnoughCoin(_shopItemList[itemIndex]._price))
        {
            Game.Instance.UseCoin(_shopItemList[itemIndex]._price);
            // purshed item
            _shopItemList[itemIndex]._isPurchased = true;

            // disable the button
            _buyButton = _shopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
            DisableBuybutton();

            // change ui text
            Game.Instance.UpdateSetAllCoinsUIText();

            // add avatar
            Profile.Instance.AddAvatar(_shopItemList[itemIndex].Image);
        }
        else
        {
            _noCoinsAnim.SetTrigger("NoCoin");
            Debug.Log("no coin");
        }

    }

    void DisableBuybutton()
    {
        _buyButton.interactable = false;
        _buyButton.transform.GetChild(0).GetComponent<Text>().text = "PURCHASED";
    }

    public void OpenShop()
    {
        _shopPanel.SetActive (true);

    }  

    public void CloseShop()
    {
        _shopPanel.SetActive (false);
    }
}
