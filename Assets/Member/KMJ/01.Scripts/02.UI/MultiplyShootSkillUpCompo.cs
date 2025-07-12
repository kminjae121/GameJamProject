using UnityEngine;

public class MultiplyShootUpGrade : SkillUpCompo
{
    [SerializeField] private PlayerAttackCompo _atkCompo;
    public override void UpSkillLevel()
    {
        _atkCompo.shootCnt += 1;
        base.UpSkillLevel();
    }
}
