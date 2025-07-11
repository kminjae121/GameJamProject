using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : Monosingleton<SceneChangeManager>
{

    public int stageNum = 0;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void LoadScene(int sceneNum)
    {
        SceneManager.LoadSceneAsync(sceneNum);
    }

    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void RestartScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
