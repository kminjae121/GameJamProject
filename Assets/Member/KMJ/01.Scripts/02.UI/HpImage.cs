using System;
using Code.Combat;
using UnityEngine;
using UnityEngine.UI;

public class HpImage : MonoBehaviour
{
    [SerializeField] private Image _image;

    [SerializeField] private EntityHealth health;


    private void Update()
    {
        _image.fillAmount = health.CurrentHealth / health.MaxHealth;
    }
}
