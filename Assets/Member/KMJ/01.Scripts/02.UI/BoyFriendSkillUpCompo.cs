using UnityEngine;

public class BoyFriendSkillUpCompo : SkillUpCompo
{
    [SerializeField] private BoyFriendSkill _boyFriend;

    [SerializeField] private float modifierValues;
    public override void UpSkillLevel()
    {
        base.UpSkillLevel();

        if (_skillSO != null)
        {
            _boyFriend.gameObject.SetActive(true);
        }
        else
        {
            _boyFriend.speed += modifierValues;
        }
    }
}
