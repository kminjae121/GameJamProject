using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using MaskTransitions;

public class TilteUI : MonoBehaviour
{
    [SerializeField] private Image settingUI;

    private void Awake()
    {
        settingUI.gameObject.SetActive(false);
    }

    public async void StartBnt()
    {
        TransitionManager.Instance.PlayTransition(1.5f);
        await Awaitable.WaitForSecondsAsync(0.5f);
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
