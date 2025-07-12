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
    [SerializeField] private Color color;
    private ParticleSystem _playEffect;
    public override void CreateFeedback()
    {
        _playEffect = hitParticle;
        Quaternion rotation = Quaternion.LookRotation(actionData.HitNormal * -1);
        _playEffect = Instantiate(_playEffect, actionData.HitPoint, rotation);
        _playEffect.Play();

        sprite.color = color;

        Vector2 knockBackDirection = actionData.HitDir;

        rbCompo.AddForce(knockBackDirection * 3f,ForceMode2D.Impulse);
        StopFeedback();
    }

    public override void StopFeedback()
    {
         Destroy(_playEffect);
    }
}
