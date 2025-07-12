using UnityEngine;

public class Wall : SkillCompo
{
    [SerializeField] private GameObject _WallObjPrefabs;
    public override void GetSkill()
    {
        base.GetSkill();
        _WallObjPrefabs.SetActive(true);   
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
    }
}
