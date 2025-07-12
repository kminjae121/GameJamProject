using UnityEngine;

public class MultipleShoot : SkillCompo
{
    [SerializeField] private PlayerAttackCompo _playerAttackCompo;
    public override void GetSkill()
    {
        _playerAttackCompo.shootCnt += 1;
        base.GetSkill();
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
