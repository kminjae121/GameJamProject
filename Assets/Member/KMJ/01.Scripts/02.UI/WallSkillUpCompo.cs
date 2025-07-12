using System.Threading;
using UnityEngine;

public class WallSkillUpCompo : SkillUpCompo
{
    [SerializeField] private BarrierCompo _barrier;

    [SerializeField] private float modifierValues;
    public override void UpSkillLevel()
    {
        base.UpSkillLevel();

            _barrier.transform.localScale += new Vector3(1, 1, 0);

    }
}
