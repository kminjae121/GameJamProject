using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using Cursor = UnityEngine.Cursor;

namespace Member.KMJ._01.Scripts
{
    public class CardSystem : MonoBehaviour
    {
        private RectTransform _rect;
        public static CardSystem instance;
        [field: SerializeField] public List<GameObject> itemList { get; set; }

        public bool isShow { get; set; } = false;
        // [SerializeField] private PlayerInputSO _inputReader;

        [SerializeField] private List<GameObject> _selectObj;

        private void Awake()
        {
            instance = this;
            _rect = GetComponent<RectTransform>();
            // _inputReader.OnFirstSelect += SelectFirst;
            //  _inputReader.OnSecondSelect += SelectSecond;
            //_inputReader.OnThridSelect += SelectThrid;
            
            Hide();
        }

        private void Start()
        {
            
        }

        private void SelectSecond()
        {
            if (!isShow)
                return;
            _selectObj[1].GetComponentInChildren<Button>().onClick?.Invoke();
        }

        private void SelectFirst()
        {
            if (!isShow)
                return;
            _selectObj[0].GetComponentInChildren<Button>().onClick?.Invoke();
        }

        private void SelectThrid()
        {
            if (!isShow)
                return;
            _selectObj[2].GetComponentInChildren<Button>().onClick?.Invoke();
        }

        public void Show()
        {
            RandomItem();
            Time.timeScale = 0;
            _rect.localScale = Vector3.one;
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            isShow = true;
        }

        public void Hide()
        {
            _rect.localScale = Vector3.zero;
            itemList.ToList().ForEach(UI => UI.SetActive(false));
            isShow = false;
            Time.timeScale = 1;
            Cursor.visible = false;
            isShow = false;
            FadeUI.Instance.FindTxt("StageTxt").gameObject.SetActive(true);
            FadeUI.Instance.FindTxt("StageTxt").alpha = 255f;
            
            FadeUI.Instance.FindTxt("StageTxt").text = $"Stage{GameManager.Instance._currentwave}";
            FadeUI.Instance.FadeTxt(0, 3, "StageTxt");
        }

        public void RandomItem()
        {
            itemList.ToList().ForEach(UI => UI.SetActive(false));
            int maxCount = itemList.Count;

            int[] ran = new int[3];

            while (true)
            {
                ran[0] = Random.Range(0, maxCount);
                ran[1] = Random.Range(0, maxCount);
                ran[2] = Random.Range(0, maxCount);

                if (ran[0] != ran[1] && ran[1] != ran[2] && ran[2] != ran[0])
                    break;
            }

            for (int i = 0; i < 3; i++)
            {
                GameObject obj = itemList[ran[i]];
                obj.transform.SetSiblingIndex(i);
                obj.SetActive(true);
            }

            for (int i = 0; i < 3; i++)
            {
                _selectObj[i] = transform.GetChild(i).gameObject;
            }
        }
    }
}