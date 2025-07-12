using UnityEngine;

public class BoyFriendSkillUpCompo : SkillUpCompo
{
    [SerializeField] private BoyFriendSkill _boyFriend;

    [SerializeField] private int modifierValue;
    public override void UpSkillLevel()
    {
        base.UpSkillLevel();
        _boyFriend.speed += modifierValue;
    }
}
