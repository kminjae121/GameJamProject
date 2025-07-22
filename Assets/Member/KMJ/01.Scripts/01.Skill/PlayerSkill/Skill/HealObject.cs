using UnityEngine;

public class HealObject : SkillCompo
{
    [SerializeField] private EnemySpawnData _healObject;

    [SerializeField] private EnemySpawnDataList _spawnDataList;
    public override void GetSkill()
    {
        base.GetSkill();
        _spawnDataList.datas.Add(_healObject);
    }
    
    
    protected override void Skill()
    {
        base.Skill();
    }

    public override void SkillFeedback()
    {
        base.SkillFeedback();
    }

    public override void EventDefault()
    {
        base.EventDefault();
        _spawnDataList.datas.Remove(_healObject);
    }
}
