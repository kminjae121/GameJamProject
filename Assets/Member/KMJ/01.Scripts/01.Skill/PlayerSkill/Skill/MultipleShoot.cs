using Code.Player;

public class MultipleShoot : SkillCompo
{
    private PlayerAttackCompo _playerAttackCompo;
    public override void GetSkill()
    {
        _playerAttackCompo = _entity.GetComponentInChildren<PlayerAttackCompo>();
        
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
