using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatSO", menuName = "StatSystem/StatSO", order = 0)]
public class StatSO : ScriptableObject, ICloneable
{
    public delegate void ValueChangeHandler(StatSO stat, float currentValue, float prevValue);
    public event ValueChangeHandler OnValueChanged;

    public string statName;
    public string description;
    [SerializeField] private Sprite icon;
    [SerializeField] private string displayName;
    [SerializeField] private float baseValue, minValue, maxValue;

    private Dictionary<object, float> _modifyValueByKey = new Dictionary<object, float>();

    [field: SerializeField] public bool IsPercent { get; private set; }

    private float _modifiedValue = 0;
    public Sprite Icon => icon;

    public float MaxValue
    {
        get => maxValue;
        set => maxValue = value;
    }

    public float MinValue
    {
        get => minValue;
        set => minValue = value;
    }

    public float Value => Mathf.Clamp(baseValue + _modifiedValue, MinValue, MaxValue);
    public bool IsMax => Mathf.Approximately(Value, MaxValue);
    public bool IsMin => Mathf.Approximately(Value, MinValue);

    public float BaseValue
    {
        get => baseValue;
        set
        {
            float prevValue = value;
            baseValue = Mathf.Clamp(value, MinValue, MaxValue);
            TryInvokeValueChangeEvent(value, prevValue);
        }
    }

    public void AddModifier(object key, float value)
    {
        if (_modifyValueByKey.ContainsKey(key)) return;

        float prevValue = Value;
        _modifiedValue += value;
        _modifyValueByKey.Add(key, value);
        TryInvokeValueChangeEvent(Value, prevValue);
    }

    public void RemoveModifier(object key)
    {
        if (_modifyValueByKey.TryGetValue(key, out float value))
        {
            float prevValue = Value;
            _modifiedValue -= value;
            _modifyValueByKey.Remove(key);
            TryInvokeValueChangeEvent(Value, prevValue);
        }
    }

    public void ClearModifier()
    {
        float prevValue = Value;
        _modifyValueByKey.Clear();
        _modifiedValue = 0;
        TryInvokeValueChangeEvent(Value, prevValue);
    }

    private void TryInvokeValueChangeEvent(float value, float prevValue)
    {
        if(Mathf.Approximately(value, prevValue) == false)
        {
            OnValueChanged?.Invoke(this, Value, prevValue);
        }
    }
    
    public object Clone()
    {
        return Instantiate(this); 
    }
}