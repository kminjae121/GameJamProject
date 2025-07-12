using System;
using UnityEngine;
using UnityEngine.UI;

public class SkillImageCompo : MonoBehaviour
{
    [SerializeField] private Image skillFillImage;
    [SerializeField] private EntitySkillCompo _skillCompo;
    private SkillCompo _skill;
    [SerializeField] private SkillSO _skillSO;

    private void Awake()
    {
        var type = Type.GetType(_skillSO.className);
            
        var components = _skillCompo.GetComponentsInChildren(type, true);

        if (components.Length > 0)
        {
            _skill = components[0] as SkillCompo;
        }
    }

    private void Update()
    {
        skillFillImage.fillAmount = (_skill.currentcoolTime / _skill.skillCoolTime);
    }
}
