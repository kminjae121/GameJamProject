using System.Threading;
using UnityEngine;

public class WallSkillUpCompo : SkillUpCompo
{
    [SerializeField] private BarrierCompo _barrier;

    [SerializeField] private float modifierValue;
    public override void UpSkillLevel()
    {
        base.UpSkillLevel();
        if (_skillSO != null)
        {
            _barrier.gameObject.SetActive(true);
        }
        else
        {
            _barrier.modifierValue += modifierValue;
        }

    }
}
