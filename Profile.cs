using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Profile : MonoBehaviour
{
    #region SIngleton : Profile
    public static Profile Instance;
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

    public class Avatar
    {
        public Sprite Image;
    }

    [SerializeField] GameObject _profilePanelHolder;
    [SerializeField] GameObject _upgradePanelHolder;
    [SerializeField] GameObject _ball;

    public List<Avatar> _avatarsList;
    [SerializeField] GameObject _avatarUITemplate;
    [SerializeField] Transform _avatarsScrollView; // content

    GameObject _holder;
    public int _newSelectedIndex, _previousSelectedIndex;

    [SerializeField] Color _activeAvatarColor;
    [SerializeField] Color _defaultAvatarColor;

   //[SerializeField] Image _currentAvatar;

    



    void Start()
    {
        GetAvaibleAvatar();
        _newSelectedIndex = _previousSelectedIndex = 0;
    }
    
    void GetAvaibleAvatar()
    {
        for (int i = 0; i < ShopMenu.Instance._shopItemList.Count; i++) // get avatar from shop
        {
            if (ShopMenu.Instance._shopItemList[i]._isPurchased)
            {
                // add all purchased avatars to avatarsList
                AddAvatar(ShopMenu.Instance._shopItemList[i].Image);
            }
        }
        SelectedAvatar(_newSelectedIndex);
    }

    public void AddAvatar(Sprite _img)
    {
        if(_avatarsList == null)
        {
            _avatarsList = new List<Avatar>();
        }
        Avatar _av = new Avatar() { Image = _img };
        // Add av to _avatarList
        _avatarsList.Add(_av);
        // Add avatar in the ui scroll view 
        _holder = Instantiate(_avatarUITemplate, _avatarsScrollView);
        _holder.transform.GetChild(0).GetComponent<Image>().sprite = _av.Image;

        //add click event
        _holder.transform.GetComponent<Button>().AddEventListener(_avatarsList.Count - 1, OnAvatarClick); // _avatarsList.Count-1 == the last item added to the list
    }

    void OnAvatarClick(int _avatarIndex)
    {
        SelectedAvatar(_avatarIndex);
    }


    void SelectedAvatar(int _avatarIndex)
    {
        _previousSelectedIndex = _newSelectedIndex;
        _newSelectedIndex = _avatarIndex;
        _avatarsScrollView.GetChild(_previousSelectedIndex).GetComponent<Image>().color = _defaultAvatarColor; // default color ;
        _avatarsScrollView.GetChild(_newSelectedIndex).GetComponent<Image>().color = _activeAvatarColor; // active color ;

        //change avatar
        
        for (int i = 0; i < _avatarsList.Count; i++)
        {
            _ball.transform.GetChild(i).gameObject.SetActive(false);
        }
        _ball.transform.GetChild(_avatarIndex).gameObject.SetActive(true);
        Debug.Log(_avatarIndex) ;
    }


    public void OpenProfile()
    {
        Game.Instance._gameStop = true;
        _profilePanelHolder.SetActive(true);
        _upgradePanelHolder.SetActive(false);
    }
    public void CloseProfile()
    {
        Game.Instance._gameStop = false;
        _profilePanelHolder.SetActive(false);
        _upgradePanelHolder.SetActive(true);
    }


}
