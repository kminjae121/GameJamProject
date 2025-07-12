using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
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

        [SerializeField] private List<GameObject> _selectObj;

        public GameObject _lockObj;

        [SerializeField] private Sprite _lockSprite;
        [SerializeField] private Sprite _unLockSprite;

        [SerializeField] private GameObject exitBtn;
        [SerializeField] private GameObject rerollBtn;

        [SerializeField] private InputReader _inputReader;
        private void Awake()
        {
            instance = this;
            _rect = GetComponent<RectTransform>();
            
            Hide();
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            foreach (var skillObj in itemList)
            {
                Transform lockImg = FindDeepChild(skillObj.transform, "LockImg");

                var img = lockImg.GetComponent<Image>();
                
                if (lockImg.transform.parent.gameObject == _lockObj)
                {
                    img.sprite = _lockSprite;
                }
                else
                {
                    img.sprite = _unLockSprite;
                }
            }
        }
        
        Transform FindDeepChild(Transform parent, string name)
        {
            foreach (Transform child in parent)
            {
                if (child.name == name)
                    return child;

                var result = FindDeepChild(child, name);
                if (result != null)
                    return result;
            }
            return null;
        }


        public void LockObject(GameObject lockObj)
        {
            if (_lockObj == lockObj)
            {
                _lockObj = null;
                return;
            }
            _lockObj = lockObj;
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
            _rect.localScale = Vector3.zero;
            rerollBtn.SetActive(true);
            exitBtn.SetActive(true);
            _rect.transform.DOScale(1f, 0.8f).SetEase(Ease.OutBack).SetUpdate(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            _inputReader.OnDisable();
            isShow = true;
        }

        public void Hide()
        {
            _rect.transform.DOScale(0f, 0.5f).SetEase(Ease.InBack).SetUpdate(true).OnComplete(() =>
            {
                itemList.ToList().ForEach(UI => UI.SetActive(false));
                rerollBtn.SetActive(false);
                exitBtn.SetActive(false);
                isShow = false;
                Time.timeScale = 1;
                isShow = false;
                _inputReader.OnEnable();
            });
        }
        
        public void Reroll()
        {
            if (GameManager.Instance.coin < 10)
                return;
            Show();
            GameManager.Instance.MinusCoin(10);
        }

        public void RandomItem()
        {
            itemList.ToList().ForEach(UI => UI.SetActive(false));

            List<GameObject> availableItems = new List<GameObject>(itemList);

            if (_lockObj != null)
            {
                _lockObj.transform.SetSiblingIndex(0);
                _lockObj.SetActive(true);
                _selectObj[0] = _lockObj;
                
                availableItems.Remove(_lockObj);
                
                List<GameObject> randoms = availableItems.OrderBy(x => Random.value).Take(2).ToList();

                for (int i = 0; i < 2; i++)
                {
                    GameObject obj = randoms[i];
                    obj.transform.SetSiblingIndex(i + 1);
                    obj.SetActive(true);
                    _selectObj[i + 1] = obj;
                }
            }
            else
            {
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
                    _selectObj[i] = obj;
                }
            }
        }
    }
}