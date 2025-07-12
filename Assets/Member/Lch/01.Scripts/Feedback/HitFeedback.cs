using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class HitFeedback : Feedback
{
    [SerializeField] private ParticleSystem hitParticle;
    [SerializeField] private float playDuration = 0.1f;
    [SerializeField] private ActionData actionData;
    public override async void CreateFeedback()
    {
        ParticleSystem particleSystem = hitParticle;
        Quaternion rotation = Quaternion.LookRotation(actionData.HitNormal * -1);
        particleSystem = Instantiate(particleSystem, actionData.HitPoint, rotation);
        particleSystem.Play();
        await Awaitable.WaitForSecondsAsync(playDuration);
        Destroy(particleSystem.gameObject);
    }

    public override void StopFeedback()
    {
        
    }
}
