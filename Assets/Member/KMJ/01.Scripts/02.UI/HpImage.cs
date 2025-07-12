using System;
using Blade.Core;
using Code.Combat;
using UnityEngine;
using UnityEngine.UI;

public class HpImage : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private EntityHealth health;

    private float _prevHp = 0f;
    private void Awake()
    {
    }

    private void Update()
    {
        _image.fillAmount = Mathf.Lerp(_prevHp,  1 - health.CurrentHealth / health.MaxHealth, 1f);
        _prevHp = 1 - health.CurrentHealth / health.MaxHealth;
    }
}
