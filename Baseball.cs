using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baseball : MonoBehaviour
{
    GameObject _tork;
    private float _tailDropper;
    [SerializeField] float _tailRate;
    private float _tailSizeChanger;

    [System.Obsolete]
    private void Start()
    {
        _tork = GameObject.FindGameObjectWithTag("Tork");
    }

    [System.Obsolete]
    private void Update()
    {
        TailSpeed();
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BaseballBat"))
        {
            transform.GetChild(Profile.Instance._newSelectedIndex).GetComponent<ParticleSystem>().startLifetime = _tork.GetComponent<Torque>()._maxAngVel / 20;
        }
        if (other.CompareTag("StarterObj"))
        {
            Game.Instance._gameStop = false;
        }
    }

    [System.Obsolete]
    void TailSpeed()
    {
        if (Time.time > _tailDropper)
        {
            _tailDropper = Time.time + _tailRate;
            transform.GetChild(Profile.Instance._newSelectedIndex).GetComponent<ParticleSystem>().startLifetime -= 0.01f;
        }

        //if (_tork.GetComponent<Torque>()._maxAngVel < 5)
        //{

        //    _tailParticle.gameObject.transform.localScale -= new Vector3(.02f, .02f, .02f);

        //}
        //else
        //{
        //    _tailParticle.gameObject.transform.localScale += new Vector3(.02f, .02f, .02f);
        //    Debug.Log(_tailParticle.gameObject.transform.localScale);
        //}
    }
}

