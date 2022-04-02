using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HitControl : MonoBehaviour
{
    GameObject _tork;
    GameObject _ui;
    [SerializeField] Transform _particlePos;
    [SerializeField] ParticleSystem _hitParticle;
    private int _randomHitSound;
    public float _speedBooster;

    [SerializeField] BoxCollider _collider;

    private void Start()
    {
        _tork = GameObject.FindGameObjectWithTag("Tork");
        _ui = GameObject.FindGameObjectWithTag("UIManager");
        _collider = GetComponent<BoxCollider>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            HitSound();
            BallSpeed();

            Instantiate(_hitParticle, _particlePos.position, Quaternion.identity);
        }
    }
    private void HitSound()
    {
        _randomHitSound = Random.Range(1,5);
        FindObjectOfType<AudioManager>().Play("Hit_" + _randomHitSound);
    }

    private void BallSpeed()
    {
        _tork.GetComponent<Torque>()._maxAngVel += _speedBooster;
        _tork.GetComponent<Torque>()._spinForce += _speedBooster;
    }

    public void ColliderResize(float _colliderResize)
    {
        _collider.size += new Vector3(_colliderResize, _colliderResize, _colliderResize);
    }

}
