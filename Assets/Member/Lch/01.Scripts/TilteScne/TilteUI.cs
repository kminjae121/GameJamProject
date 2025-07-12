using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class TilteUI : MonoBehaviour
{
    [SerializeField] private Image settingUI;

    private void Awake()
    {
        settingUI.gameObject.SetActive(false);
    }

    public async void StartBnt()
    {
        TransitionManager.instance.CircleTransitionFadeIn();
        await Awaitable.WaitForSecondsAsync(1.5f);
        SceneManager.LoadScene(2);
    }


    public void SettingBnt()
    {
        settingUI.gameObject.SetActive(true);
    }

    public void LevelGame()
    {
        Application.Quit();
    }
}
