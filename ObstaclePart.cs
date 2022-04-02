using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePart : MonoBehaviour
{

    Rigidbody _rb;
    float x, y, z;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        ForceVector();
        _rb.AddForce(new Vector3(x, y, z)*FindObjectOfType<Torque>()._spinForce*15);
    }
    private void ForceVector()
    {
        x = Random.Range(transform.localPosition.x -5, transform.localPosition.x + 10);
        y = Random.Range(0, 10);
        z = Random.Range(3, 7);
    }
}
