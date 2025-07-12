using System;
using System.Collections.Generic;
using Member.KMJ._01.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillUpCompo : MonoBehaviour
{
    [SerializeField] protected SkillSO _skillSO;
    [SerializeField] protected EntitySkillCompo _skillCompo;
    protected SkillCompo _skill;
    protected int _countIdx;
    protected int _currentSkill = 0;

    [SerializeField] protected int _maxskillPoint;
    
    [SerializeField] protected Image _skillimage;

    [SerializeField] protected int price = 10;

    [SerializeField] protected int modifierValue;

    [SerializeField] protected TextMeshProUGUI priceTxt;
    
    private void Awake()
    {
        var type = Type.GetType(_skillSO.className);
            
        var components = _skillCompo.GetComponentsInChildren(type, true);

        if (components.Length > 0)
        {
            _skill = components[0] as SkillCompo;
        }
        _currentSkill = 0;

        priceTxt.text = $"가격 : {price}원";
    }

    private void Update()
    {
    }
    
}
