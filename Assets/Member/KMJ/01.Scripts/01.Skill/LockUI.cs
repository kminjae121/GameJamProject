using System;
using Member.KMJ._01.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LockUI : MonoBehaviour
{
    [SerializeField] private CardSystem _cardSystem;

    [SerializeField] private Sprite _LockImg;

    [SerializeField] private Sprite _unLockImg;
    public void Lock()
    {
        foreach (var skillObj in _cardSystem.itemList)
        {
            Transform lockImg = FindDeepChild(skillObj.transform, "LockImg");

            if (lockImg != null)
            {
                var img = lockImg.GetComponent<Image>();
                if (img != null)
                {
                    img.sprite = _unLockImg;
                }
                else
                {
                    Debug.LogWarning("LockImg 오브젝트에 Image 컴포넌트가 없음!");
                }
            }
            else
            {
                Debug.LogWarning($"'{skillObj.name}' 안에서 LockImg를 못 찾음");
            }
        }
        if(_cardSystem._lockObj == null)
            return;
        
        foreach (Transform child in _cardSystem._lockObj.transform)
        {
            if (child.gameObject.name == "LockImg")
            {
                if (child.transform.parent.gameObject == _cardSystem._lockObj.gameObject)
                {
                    child.gameObject.GetComponent<Image>().sprite = _unLockImg;
                    _cardSystem._lockObj = null;
                    return;
                }
                else
                {
                    child.gameObject.GetComponent<Image>().sprite = _LockImg;
                    return;
                }
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

    private void Update()
    {
        
    }
}
