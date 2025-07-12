using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    private TextMeshPro damageText;
    private Camera mainCamera;

    private void Awake()
    {
        damageText = GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }
    
    public void SetDamageText(float damage) => damageText.text = Mathf.RoundToInt(damage).ToString();

    private void OnEnable()
    {
        damageText.transform.localScale = Vector3.one;
        damageText.transform.DOScale(0f, 0.5f).SetEase(Ease.InBack);
    }
}