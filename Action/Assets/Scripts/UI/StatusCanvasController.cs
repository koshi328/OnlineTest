using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusCanvasController : MonoBehaviour {
    [SerializeField]
    GaugeController _hpGauge;
    [SerializeField]
    GaugeController _mpGauge;
    [SerializeField]
    Actor _target;

    public void SetHP(int maxHP, int currentHP)
    {
        _hpGauge.SetFill(currentHP / (float)maxHP);
    }

    public void SetMP(int maxMP,int currentMP)
    {
        _mpGauge.SetFill(currentMP / (float)maxMP);
    }

    private void Update()
    {
        if (!_target) return;
        SetHP(_target.GetMaxHP(), _target.GetCurrentHP());
    }
}
