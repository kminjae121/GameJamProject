using System;
using Blade.Core;
using DG.Tweening;
using Member.KMin._00_Scene._01_Code.Misc;
using UnityEngine;

public class ItemEarnAnimation : MonoBehaviour
{
    [SerializeField] private GameEventChannel eventChannel;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private RectTransform coinRect;
    [SerializeField] private RectTransform canvasRect;

    private void Awake()
    {
        eventChannel.AddListener<EnemyDeadEvent>(HandleEnemyDead);
    }

    private void HandleEnemyDead(EnemyDeadEvent channel)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(channel.deadPosition);
        
        GameObject coinUI = Instantiate(coinPrefab, canvasRect);
        RectTransform coinUIRect = coinUI.GetComponent<RectTransform>();
        coinUIRect.transform.position = screenPos;

        coinUIRect.transform.localScale = Vector2.one * 2;
        coinUIRect.transform.DOScale(1f, 1f).SetUpdate(true);
        coinUIRect.DOMove(coinRect.transform.position, 1.5f).SetEase(Ease.InExpo)
            .SetUpdate(true).OnComplete(() =>
        {
            coinUI.SetActive(false);
        });
    }
}
