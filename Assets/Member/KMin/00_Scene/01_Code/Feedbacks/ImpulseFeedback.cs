using Unity.Cinemachine;
using UnityEngine;

namespace Code.Feedbacks
{
    public class ImpulseFeedback : Feedback
    {
        [SerializeField] private CinemachineImpulseSource _impulseSource;
        [SerializeField] private float impulseForce;
        
        public override void CreateFeedback()
        {
            _impulseSource.GenerateImpulse(impulseForce);
        }

        public override void StopFeedback()
        {
        }
    }
}