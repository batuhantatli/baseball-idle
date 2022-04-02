using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torque : MonoBehaviour
{
    Rigidbody _rb;

    [Header("Physics")]
    [SerializeField] float _angDrag;
    public float _spinForce;
    public float _maxAngVel;
    public float _baseSpeed;

    [Header("Speed Control")]
    public float _fireRate;

    private float _speedDropper;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        TorquePower();
    }

    void TorquePower()
    {
        if (Time.time > _speedDropper && _maxAngVel > _baseSpeed)
        {
            _speedDropper = Time.time + _fireRate;
            _maxAngVel--;
            _spinForce--;
        }
        _rb.angularDrag = _angDrag;
        _rb.maxAngularVelocity = _maxAngVel;
        _rb.AddTorque(0, 10 * _spinForce, 0);
    }
}
