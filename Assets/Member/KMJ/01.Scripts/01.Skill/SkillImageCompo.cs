using System;
using UnityEngine;
using UnityEngine.UI;

public class SkillImageCompo : MonoBehaviour
{
    [SerializeField] private Image skillFillImage;
    [SerializeField] private string _skillname;
    [SerializeField] private EntitySkillCompo _skillCompo;
    private SkillCompo _skill;


    private void Awake()
    {
        var type = Type.GetType(_skillname);
            
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
