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
        // カメラの方向を前にする
        if (x != 0 || z != 0)
        {
            Vector3 cameraDir = transform.position - _mainCamera.transform.position;
            float angle = Mathf.Atan2(cameraDir.z, cameraDir.x) + Mathf.Atan2(-x, z);
            x = Mathf.Cos(angle);
            z = Mathf.Sin(angle);
        }
        Vector3 vel = new Vector3(x, 0, z).normalized * _speed * Time.deltaTime;
        bool isRun = Vector3.Distance(Vector3.zero, vel) >= 0.01f;
        _myAnimator.SetBool("Run", isRun);
        if (!isRun) return;
        base.Movement(x, z, speed);
    }

    Vector3 _mouseDownPos;
    Vector3 _angleAmount;
    void CameraUpdate()
    {
        if(Input.GetMouseButtonDown(1))
        {
            _mouseDownPos = Input.mousePosition;
        }
        else if(Input.GetMouseButton(1))
        {
            Vector3 dir = Input.mousePosition - _mouseDownPos;
            _mouseDownPos = Input.mousePosition;
            _angleAmount -= dir;
            _angleAmount.y = Mathf.Clamp(_angleAmount.y, 0.0f, 90.0f);
        }
        _mainCamera.transform.position = transform.position;
        _mainCamera.transform.rotation = Quaternion.Euler(_angleAmount.y, _angleAmount.x, 0);
        _mainCamera.transform.Translate(Vector3.back * 5);
        _mainCamera.transform.position += new Vector3(0, 2, 0);
    }
}
