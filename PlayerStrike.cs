using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStrike : MonoBehaviour
{
    public Animator _anim;
    [SerializeField] float _playerHp;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _anim.SetTrigger("Hit");
            
        }
    }

}
