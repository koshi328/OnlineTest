using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor {


    [SerializeField]
    float _speed;
    [SerializeField]
    Actor _target;

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
        if (!_target) return;
        Vector3 dir = _target.transform.position - transform.position;
        Movement(dir.x, dir.z, _speed);

    }

    public override void Movement(float x, float z, float speed)
    {
        base.Movement(x, z, speed);
    }
}
