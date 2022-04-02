using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider _slider;
    public float _maxHealth;
    public float _currentHealth;

    private void Start()
    {
        GameStarted();
    }

    public void SetMaxHealth(float _health)
    {
        _slider.maxValue = _health;
        _slider.value = _health;
    }

    public void SetHealth (float _health)
    {
        _slider.value = _health;
    }

    public void GameStarted()
    {
        _currentHealth = _maxHealth;
        SetMaxHealth(_maxHealth);
    }

    public void TakeDamage(float _damage)
    {
        _currentHealth -= _damage;
        SetHealth(_currentHealth);
        if (_currentHealth <= 0)
        {
            Game.Instance.transform.GetChild(0).transform.GetChild(3).GetComponent<Restart>().GameOver();
        }
    }


}
