using System;
using System.Collections.Generic;
using Member.KMJ._01.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class SkillUpCompo : MonoBehaviour
{
    [SerializeField] private SkillSO _skillSO;
    [SerializeField] private EntitySkillCompo _skillCompo;
    private SkillCompo _skill;
    private int _countIdx;
    private int _currentSkill = 0;
    
    [SerializeField] private Image _skillimage;

    private void Awake()
    {
        var type = Type.GetType(_skillSO.className);
            
        var components = _skillCompo.GetComponentsInChildren(type, true);

        if (components.Length > 0)
        {
            _skill = components[0] as SkillCompo;
        }
        _currentSkill = 0;
    }

    private void Update()
    {
    }
        
    public void UpSkillLevel()
    {
        if (_skillSO == null)
        {
            _skill.skillLevel+=1;
            
            _currentSkill+=1;
            
            if (_currentSkill == 2)
            {
                int myIndex = CardSystem.instance.itemList.IndexOf(gameObject);
                if (myIndex >= 0)
                {
                    _countIdx = myIndex;
                    CardSystem.instance.itemList.RemoveAt(_countIdx);
                }
                gameObject.SetActive(false);
            }   
        }
        else
        {
            _skillCompo.AddSkill(_skillSO);
            Color color = _skillimage.color;
            color.a = Mathf.Clamp01(1);
            _skillimage.color = color;
            _skillSO = null;
        }
    }
}
