using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Member.KMin._00_Scene._01_Code.Misc
{
    public class GameOverScene : MonoBehaviour
    {
        [SerializeField] private Image background;

        private void Start()
        {
            background.DOFade(0f, 1f);
        }
    }
}