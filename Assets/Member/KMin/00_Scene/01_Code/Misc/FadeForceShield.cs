using System;
using DG.Tweening;
using UnityEngine;

namespace Member.KMin._00_Scene._01_Code.Misc
{
    public class FadeForceShield : MonoBehaviour
    {
        [SerializeField] private float threshold;
        [SerializeField] private float duration;
        
        private SpriteRenderer _spriteRenderer;
        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.DOFade(threshold, duration).SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.OutBack);
        }
    }
}