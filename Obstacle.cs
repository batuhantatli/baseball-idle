using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Transform _lastPos;
    public float _moveSpeed;
    [SerializeField] GameObject _brokenObj;
    private GameObject _spawnedBrokenObj;


    public void Update()
    {
        if (Game.Instance._gameStop == true)
            return;
        transform.position = Vector3.MoveTowards(transform.position, _lastPos.position, _moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (FindObjectOfType<Torque>()._spinForce > 5)
                Game.Instance._coins += 20;
            Breaking();
        }

    }
    public void Breaking()
    {
        Game.Instance._coins += 5;
        Game.Instance.UpdateSetAllCoinsUIText();
        _spawnedBrokenObj = Instantiate(_brokenObj, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(_spawnedBrokenObj, 1);
    }
    private void OnDestroy()
    {
        
    }
}
