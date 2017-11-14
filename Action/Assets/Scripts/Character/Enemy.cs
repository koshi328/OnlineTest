using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor {


    [SerializeField]
    float _speed;

    // Use this for initialization
    void Start()
    {
        _name = "enemy";
        _maxHP = 100;
        _currentHP = _maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Random.Range(-1, 2);
        float z = Random.Range(-1, 2);
        Movement(x, z, _speed);

    }

    public override void Movement(float x, float z, float speed)
    {
        base.Movement(x, z, speed);
    }
}
