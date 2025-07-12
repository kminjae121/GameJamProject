using DG.Tweening;
using NUnit.Framework.Internal;
using UnityEditor.EditorTools;
using UnityEngine;

public class DeadFeedback : Feedback
{
    [SerializeField] private ParticleSystem hitParticle;
    [SerializeField] private float playDuration = 0.5f;
    [SerializeField] private ActionData actionData;
    [SerializeField] private Rigidbody2D rbCompo;
    [SerializeField] private SpriteRenderer sprite;
    private ParticleSystem _playEffect;
    public override void CreateFeedback()
    {
        _playEffect = hitParticle;
        Quaternion rotation = Quaternion.LookRotation(actionData.HitNormal * -1);
        _playEffect = Instantiate(_playEffect, actionData.HitPoint, rotation);
        _playEffect.Play();

        DOVirtual.DelayedCall(playDuration, StopFeedback);
        sprite.color = Color.black;

        Vector2 knockBackDirection = -actionData.HitDir.normalized;
        float knockBackDistance = 0.1f;
        Vector2 knockBackTarget = (Vector2)rbCompo.transform.position + (knockBackDirection * knockBackDistance);

        rbCompo.transform.DOMove(knockBackTarget, 0.1f);
    }

    public override void StopFeedback()
    {
        if(_playEffect != null)
            Destroy(_playEffect);
    }
}
