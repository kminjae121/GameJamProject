using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDeadFeedback : Feedback
{
    [SerializeField] private ParticleSystem gameOverParticle;
    [SerializeField] private GameObject canvas;
    [SerializeField] private string sceneName;

    public async override void CreateFeedback()
    {
        canvas = GameObject.Find("Canvas");
        canvas.SetActive(false);
        ParticleSystem particle = Instantiate(gameOverParticle);
        particle.Play();
        await Awaitable.WaitForSecondsAsync(5f);
        SceneManager.LoadSceneAsync(sceneName);
    }

    public override void StopFeedback()
    {
    }
}
