using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetCanvasController : MonoBehaviour {
    [SerializeField]
    GaugeController _hpGauge;
    [SerializeField]
    Text _infomation;

    public void SetHp(int maxHP,int currentHP)
    {
        _hpGauge.SetFill(currentHP / (float)maxHP);
    }
    public void SetInfo(string message)
    {
        _infomation.text = message;
    }
}
