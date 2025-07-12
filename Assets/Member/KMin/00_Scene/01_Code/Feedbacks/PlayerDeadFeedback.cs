using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Member.KMin._00_Scene._01_Code.Feedbacks
{
    public class PlayerDeadFeedback : Feedback
    {
        [SerializeField] private ParticleSystem gameOverParticle;
        [SerializeField] private GameObject canvas;
        [SerializeField] private string sceneName;
        [SerializeField] private CapsuleCollider2D capsuleCollider;

        public async override void CreateFeedback()
        {
            canvas.SetActive(false);
            ParticleSystem particle = Instantiate(gameOverParticle);
            particle.Play();
            capsuleCollider.enabled = false; 
            await Awaitable.WaitForSecondsAsync(5f);
            SceneManager.LoadSceneAsync(sceneName);
        }

        public override void StopFeedback()
        {
        }
    }
}