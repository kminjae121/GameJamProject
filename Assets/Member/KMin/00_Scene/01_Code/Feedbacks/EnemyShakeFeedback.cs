using DG.Tweening;
using UnityEngine;

namespace Member.KMin._00_Scene._01_Code.Feedbacks
{
    public class EnemyShakeFeedback : Feedback
    {
        [SerializeField] private float shakeAmplitude;
        public override void CreateFeedback()
        {
            transform.parent.DOShakePosition(0.15f, shakeAmplitude, 3,  0.5f);
        }

        public override void StopFeedback()
        {
        }
    }
}