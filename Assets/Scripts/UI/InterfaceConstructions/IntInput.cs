using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntInput : MonoBehaviour
{

    [SerializeField] static int _maxValue = 50;
    [SerializeField] static int _minValue = 1;

    [SerializeField] TextMeshProUGUI _valueText;

    int _value = _minValue;

    public void Increase()
    {
        if(_value + 1 <= _maxValue)
        {
            _value++;
        }
        setText();
    }

    public void Reduse()
    {
        if(_value - 1 >= _minValue)
        {
            _value--;
        }
        setText();
    }

    private void setText()
    {
        _valueText.text = _value.ToString();
    }

    public int value { get => _value; }
}
