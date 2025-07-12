using DG.Tweening;
using UnityEngine;

public class ItemEarnAnimation : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private RectTransform coinRect;
    [SerializeField] private RectTransform canvasRect;
    
    public void CoinAnim(Vector3 worldPosition)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPosition);
        
        GameObject coinUI = Instantiate(coinPrefab, canvasRect);
        RectTransform coinUIRect = coinUI.GetComponent<RectTransform>();
        coinUIRect.transform.position = screenPos;

        coinUIRect.transform.localScale = Vector2.one * 2;
        coinUIRect.transform.DOScale(1f, 1f);
        coinUIRect.DOMove(coinRect.transform.position, 1.5f).SetEase(Ease.InExpo).OnComplete(() =>
        {
            coinUI.SetActive(false);
        });
    }
}
