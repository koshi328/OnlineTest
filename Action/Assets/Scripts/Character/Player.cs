using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor {

    [SerializeField] float _speed;
    [SerializeField] Vector3 _cameraRelativePos = new Vector3(0, 5, -7);

    Animator _myAnimator;
    Camera _mainCamera;

	// Use this for initialization
	void Start () {
        _myAnimator = GetComponent<Animator>();
        _mainCamera = Camera.main;

        _name = "player";
        _maxHP = 100;
        _currentHP = _maxHP;
    }
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Movement(x, z, _speed);

        CameraUpdate();
    }

    public override void Movement(float x, float z, float speed)
    {
        Vector3 vel = new Vector3(x, 0, z).normalized * _speed * Time.deltaTime;
        bool isRun = Vector3.Distance(Vector3.zero, vel) >= 0.01f;
        _myAnimator.SetBool("Run", isRun);
        base.Movement(x, z, speed);
    }

    Vector3 _mouseDownPos;
    void CameraUpdate()
    {
        if(Input.GetMouseButtonDown(1))
        {
            _mouseDownPos = Input.mousePosition;
        }
        else if(Input.GetMouseButton(1))
        {
            Vector2 dir = Input.mousePosition - _mouseDownPos;
            _mouseDownPos = Input.mousePosition;
            _mainCamera.transform.Rotate(new Vector3(0, dir.x, 0));
        }
        _mainCamera.transform.position = transform.position;
        _mainCamera.transform.Translate(Vector3.back * 10);
        _mainCamera.transform.LookAt(transform.position + new Vector3(0, 1, 0));
        _mainCamera.transform.position += new Vector3(0, 2, 0);
    }
}
