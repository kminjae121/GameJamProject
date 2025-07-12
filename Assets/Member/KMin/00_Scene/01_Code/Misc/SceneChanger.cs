using MaskTransitions;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Member.KMin._00_Scene._01_Code.Misc
{
    public class SceneChanger : MonoBehaviour
    {
        public string sceneName;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(HandleSceneChange);
        }

        private async void HandleSceneChange()
        {
            TransitionManager.Instance.PlayTransition(1.5f);
            await Awaitable.WaitForSecondsAsync(0.5f);
            SceneManager.LoadScene(sceneName);
        }
    }
}