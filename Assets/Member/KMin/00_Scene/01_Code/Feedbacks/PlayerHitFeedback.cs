using DG.Tweening;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

namespace Code.Entities
{
    public class PlayerHitFeedback : Feedback, IEntityComponent
    {
        [SerializeField] private Sprite hitSprite;
        [SerializeField] private Sprite idleSprite;
        [SerializeField] private Color hitColor;
        
        private SpriteRenderer _spriteRenderer;
        public void Initialize(Entity entity)
        {
            _spriteRenderer = entity.GetComponentInChildren<SpriteRenderer>();
        }
        
        public override void CreateFeedback()
        {
            _spriteRenderer.sprite = hitSprite;
            _spriteRenderer.DOColor(hitColor, 0.2f);
            
            DOVirtual.DelayedCall(0.5f, () =>
            {
                _spriteRenderer.sprite = idleSprite;
                _spriteRenderer.DOColor(Color.white, 0.2f);
            });
        }

        public override void StopFeedback() { }
    }
}