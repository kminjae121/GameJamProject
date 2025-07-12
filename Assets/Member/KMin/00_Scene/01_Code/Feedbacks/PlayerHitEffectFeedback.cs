using UnityEngine;

namespace Code.Feedbacks
{
    public class PlayerHitEffectFeedback : Feedback
    {
        [SerializeField] private float effectDuration;
        [SerializeField] private ParticleSystem effectPrefab;

        public override async void CreateFeedback()
        {
            ParticleSystem effect = Instantiate(effectPrefab);
            effect.transform.position = transform.position;

            await Awaitable.WaitForSecondsAsync(effectDuration);
            Destroy(effect.gameObject);
        }

        public override void StopFeedback()
        {

        }
    }
}
