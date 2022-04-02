using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorqueForOriin : MonoBehaviour
{
    private float speed;
    private void Update() {
        gameObject.transform.Rotate(0,speed,0);
        speed = gameObject.transform.parent.transform.GetChild(1).GetComponent<Torque>()._spinForce; 
    }

}
