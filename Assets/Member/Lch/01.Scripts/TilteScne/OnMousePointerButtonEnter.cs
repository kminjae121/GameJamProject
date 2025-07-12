using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnMousePointerButtonEnter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float duration = 0.1f;
    [SerializeField] private float scale = 1.2f;

    private Sequence _seq;
        
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_seq != null && _seq.IsActive())
        {
            _seq.Kill();
        }

        _seq = DOTween.Sequence();
        _seq.Append(transform.DOScale(1.25f, duration * 0.45f));
        _seq.Append(transform.DOScale(0.8f, duration * 0.3f));
        _seq.Append(transform.DOScale(1.05f, duration * 0.45f));

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_seq != null && _seq.IsActive())
        {
            _seq.Kill();
        }

        _seq = DOTween.Sequence();
        _seq.Append(transform.DOScale(0.9f, duration * 0.2f));
        _seq.Append(transform.DOScale(1f, duration * 0.2f));
    }
}
