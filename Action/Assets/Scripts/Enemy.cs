using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor {


    [SerializeField]
    float _speed;

    Animator _myAnimator;
    Camera _mainCamera;

    // Use this for initialization
    void Start()
    {
        _myAnimator = GetComponent<Animator>();
        _mainCamera = Camera.main;
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
