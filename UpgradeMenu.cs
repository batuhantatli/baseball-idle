using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class UpgradeMenu : MonoBehaviour
{
    [System.Serializable]
    public class UpgradeItem
    {
        public Image _shopImage;
        public Text _levelText;
        public Text _priceText;
        public int _price;
        public int _levelCounter;
    }
    public List<UpgradeItem> _upgradeItemList;

    [Header("The effect of button")]
    [SerializeField] float _strikeSpeedBooster;
    [SerializeField] float _increaseAfterHit;
    [SerializeField] float _baseSpeedChanger;

    GameObject _baseballBat;
    GameObject _player;
    GameObject _torq;
    Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _torq = GameObject.FindGameObjectWithTag("Tork");
        _player = GameObject.FindGameObjectWithTag("Player");
        _baseballBat = GameObject.FindGameObjectWithTag("BaseballBat");
        for (int i = 0; i < _upgradeItemList.Count; i++)
        {
            _upgradeItemList[i]._priceText.text = _upgradeItemList[i]._price.ToString();
        }


    }

    public void OnShopItemBtnClicked(int itemIndex)
    {
        if (Game.Instance._coins >= _upgradeItemList[itemIndex]._price) {
            Game.Instance._coins -= _upgradeItemList[itemIndex]._price;

            _upgradeItemList[itemIndex]._price += 50;
            _upgradeItemList[itemIndex]._priceText.text = _upgradeItemList[itemIndex]._price.ToString();
            Game.Instance.UpdateSetAllCoinsUIText();
            if (itemIndex == 0)
            {
                if (_upgradeItemList[itemIndex]._levelCounter == 0)
                    _player.GetComponent<PlayerStrike>()._anim.speed += _strikeSpeedBooster * 3;
                _player.GetComponent<PlayerStrike>()._anim.speed += _strikeSpeedBooster;
                _anim.SetTrigger("StrikeTrigger");
            }
            if(itemIndex == 1)
            {
                if (_upgradeItemList[itemIndex]._levelCounter == 0)
                    _baseballBat.GetComponent<HitControl>()._speedBooster += _increaseAfterHit * 3;
                _baseballBat.GetComponent<HitControl>()._speedBooster += _increaseAfterHit;
                _anim.SetTrigger("SpeedTrigger");
            }
            if(itemIndex == 2)
            {
                if (_upgradeItemList[itemIndex]._levelCounter == 0)
                    _torq.GetComponent<Torque>()._baseSpeed += 1;
                _torq.GetComponent<Torque>()._baseSpeed += _baseSpeedChanger;
                _anim.SetTrigger("BaseSpeedTrigger");
            }
            _upgradeItemList[itemIndex]._levelCounter++;
            _upgradeItemList[itemIndex]._levelText.text = "LEVEL " + _upgradeItemList[itemIndex]._levelCounter;
        }
    }



}























    //public void StrikeSpeedBtn()
    //{
    //    if(_score > _strikeSpeedBtnPrice)
    //    {
    //        _player.GetComponent<PlayerStrike>()._anim.speed += 0.05f;
    //        //_score -= _strikeSpeedBtnPrice;
    //        //_strikeSpeedBtnPrice += 50;
    //        //_strikeSpeedPriceTxt.text = _strikeSpeedBtnPrice.ToString();
    //        //ScoreText();


    //    }
    //}
    
    //public void BallSpeedBtn()
    //{
    //    if(_score >= _ballSpeedBtnPrice)
    //    {
    //        _baseballBat.GetComponent<HitControl>()._speedBooster += 0.25f;

    //        _score -= _ballSpeedBtnPrice;
    //        _ballSpeedBtnPrice += 50;
    //        _ballSpeedPriceTxt.text = _ballSpeedBtnPrice.ToString();
    //        ScoreText();
    //    }
        
    //}

    //public void MasterBtn()
    //{
    //    if (_score >= _masterBtnPrice)
    //    {
    //        _baseballBat.GetComponent<HitControl>().ColliderResize();
    //        _score -= _masterBtnPrice;
    //        _masterBtnPrice += 50;
    //        _masterPriceTxt.text = _masterBtnPrice.ToString();
    //        ScoreText();
    //    }

    //}
