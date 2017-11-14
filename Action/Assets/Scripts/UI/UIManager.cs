using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    [SerializeField]
    TargetCanvasController _targetCanvas;
    [SerializeField]
    Cursor _cursor;

    Actor _currentTarget;
	// Use this for initialization
	void Start () {
        _targetCanvas.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        Actor target = _cursor.GetTarget();
        if (_currentTarget == target) return;
        _currentTarget = target;
        if(!_currentTarget)
        {
            _targetCanvas.gameObject.SetActive(false);
        }
        else
        {
            _targetCanvas.gameObject.SetActive(true);
            _targetCanvas.SetHp(_currentTarget.GetMaxHP(), _currentTarget.GetCurrentHP());
            _targetCanvas.SetInfo(_currentTarget.GetName());
        }
	}
}
