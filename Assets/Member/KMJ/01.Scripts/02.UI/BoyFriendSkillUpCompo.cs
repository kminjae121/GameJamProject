using UnityEngine;

public class BoyFriendSkillUpCompo : SkillUpCompo
{
    [SerializeField] private BoyFriendSkill _boyFriend;

    [SerializeField] private float modifierValues;
    public override void UpSkillLevel()
    {
        base.UpSkillLevel();
        
        _boyFriend.speed += modifierValues;
    }
}
