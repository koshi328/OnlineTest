using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeController : MonoBehaviour {

    [SerializeField]
    Image _fill;

    public void SetFill(float value)
    {
        _fill.fillAmount = value;
    }
}
