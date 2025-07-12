using DG.Tweening;
using NUnit.Framework.Internal;
using UnityEditor.EditorTools;
using UnityEngine;

public class HitFeedback : Feedback
{
    [SerializeField] private ParticleSystem hitParticle;
    [SerializeField] private float playDuration = 0.5f;
    [SerializeField] private ActionData actionData;
    private ParticleSystem _playEffect;
    public override void CreateFeedback()
    {
        _playEffect = hitParticle;
        Quaternion rotation = Quaternion.LookRotation(actionData.HitNormal * -1);
        _playEffect = Instantiate(_playEffect,actionData.HitPoint,rotation);
        DOVirtual.DelayedCall(playDuration, StopFeedback);
    }

    public override void StopFeedback()
    {
        if (_playEffect == null) return;
        Destroy(_playEffect);
    }
}
