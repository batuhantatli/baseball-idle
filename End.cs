﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] float _damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            FindObjectOfType<HealthBar>().TakeDamage(_damage);
            Destroy(other.gameObject);
        }

    }
}
