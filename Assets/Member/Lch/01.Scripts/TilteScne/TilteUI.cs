using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TilteUI : MonoBehaviour
{
    [SerializeField] private Image settingUI;

    private void Awake()
    {
        settingUI.gameObject.SetActive(false);
    }

    public void StartBnt()
    {
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
