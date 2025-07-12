using DG.Tweening;
using UnityEngine;
using DG.Tweening;

namespace Code.Entities
{
    public class PlayerHitFeedback : Feedback, IEntityComponent
    {
        [SerializeField] private Sprite hitSprite;
        [SerializeField] private Sprite idelSprite;
        [SerializeField] private Color hitColor;
        
        private SpriteRenderer _spriteRenderer;
        public void Initialize(Entity entity)
        {
            _spriteRenderer = entity.GetComponentInChildren<SpriteRenderer>();
        }
        
        public override void CreateFeedback()
        {
            _spriteRenderer.DOColor(hitColor, 0.3f);
            
            DOVirtual.DelayedCall(0.1f, () =>
            {
                _spriteRenderer.sprite = idelSprite;
                _spriteRenderer.DOColor(Color.white, 0.3f);
            });
        }

        public override void StopFeedback() { }
    }
}