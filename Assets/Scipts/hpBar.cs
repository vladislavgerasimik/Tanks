using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpBar : MonoBehaviour
{
    [SerializeField] private HpObject _hpObject;
    [SerializeField] private Slider _hpBar;

    void Start()
    {
        _hpBar.maxValue = _hpObject.MaxHp;
        _hpBar.value = _hpObject.MaxHp;
    }

   
    void Update()
    {
        _hpBar.value = _hpObject.CurrentHp;
    }
}
