using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] _obstacleObj;
    [SerializeField] float _spawnRate;
    private float _rate;
    private int _randomObj;
    public List<GameObject> _spawnedGameobj = new List<GameObject>();

    public GameObject _obstacleHolder;

    void Update()
    {
        if (Time.time > _rate && Game.Instance._gameStop == false)
        {
            _rate = Time.time + (_spawnRate / (Time.time +_spawnRate/2));
            RandomObjGenerator();
        }
    }

    void RandomObjGenerator()
    {
        
        /*
         * _spawnRate = (FindObjectOfType<UpgradeMenu>()._upgradeItemList[0]._levelCounter +
            FindObjectOfType<UpgradeMenu>()._upgradeItemList[1]._levelCounter +
            FindObjectOfType<UpgradeMenu>()._upgradeItemList[2]._levelCounter); */
        _spawnRate = Random.Range(10, 100);
        _randomObj = Random.Range(0, _obstacleObj.Length);
        _obstacleHolder = Instantiate(_obstacleObj[_randomObj], transform.position, Quaternion.identity);
        //_spawnedGameobj.Add(_obstacleHolder);
    }

    public void DestoryAllSpawnedObj()
    {
        for (int i = 0; i < _spawnedGameobj.Count; i++)
        {
            Destroy(_spawnedGameobj[i]);
        }
    }




}