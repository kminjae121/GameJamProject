using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntitySkillCompo : MonoBehaviour, IEntityComponent, IAfterInitialize
{
    [SerializeField] private List<SkillSO> _skillList;

    public float skillDamage { get; set; }
    public float BaseskillDamage { get; private set; }
    
    public Dictionary<string, SkillCompo> SkillList;

    private Player player;

    private EntityStat _statCompo;
    
    public virtual void Initialize(Entity entity)
    {
        player = entity as Player;
        SkillList = new Dictionary<string, SkillCompo>();

        if(SkillList == null)
            return;
        else
        {
            foreach (var skillSo in _skillList)
            {
                var type = Type.GetType(skillSo.className);

                if (type == null)
                    return;

                var components = entity.GetComponentsInChildren(type, true);

                if (components.Length > 0)
                {
                    SkillCompo component = components[0] as SkillCompo;

                   

                    SkillList.Add(skillSo.skillName, component);
                }
            }
        }
           

        if (SkillList == null)
            return;
        else
            SkillList.Values.ToList().ForEach(skill => skill.GetSkill());

        _statCompo = entity.GetCompo<EntityStat>();
    }

    public void AddSkill(SkillSO skillSO)
    {
        if (skillSO == null) return;
        _skillList.Add(skillSO);

        var type = Type.GetType(skillSO.className);

        var components = player.GetComponentsInChildren(type, true);
        
        if (components.Length > 0)
        {
            SkillCompo component = components[0] as SkillCompo;
             
            SkillList.Add(skillSO.skillName, component);
            SkillList.GetValueOrDefault(skillSO.skillName).GetSkill();
        }

    }


    private void Update()
    {
        if (SkillList == null)
            return;

        SkillList.Values.ToList().ForEach(skill => skill.SkillUpdate());
    }


    public void DefaltSkill()
    {
        if (SkillList == null)
            return;

        SkillList.Values.ToList().ForEach(skill => skill.EventDefault());
    }

   
    private void HandleSkillChange(StatSO stat, float currentValue, float previousValue)
    {
        skillDamage += currentValue - previousValue;
        BaseskillDamage += currentValue - previousValue;
        
    }

    public void AfterInitialize()
    {
        
    }
}

