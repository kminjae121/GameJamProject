using UnityEngine;

public class BoyFriend : SkillCompo
{
    [SerializeField] private GameObject _boyFriend;
    
    
    public override void GetSkill()
    {
        base.GetSkill();
        _boyFriend.SetActive(true);    
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
