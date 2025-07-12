using UnityEngine;

public class MultiplyShootUpGrade : SkillUpCompo
{
    [SerializeField] private PlayerAttackCompo _atkCompo;
    public override void UpSkillLevel()
    {
        base.UpSkillLevel();
        _atkCompo.shootCnt++;
    }
}
