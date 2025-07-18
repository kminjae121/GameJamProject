using Member.KMJ._01.Scripts;
using UnityEngine;

public class BoyFriendSkillUpCompo : SkillUpCompo
{
    [SerializeField] private BoyFriendSkill _boyFriend;

    [SerializeField] private float modifierValues;
    
    
    public void UpSkillLevel()
    {
        if (GameManager.Instance.coin >= price)
        {
            if (_skillSO == null)
            {
                _skill.skillLevel += 1;

                _currentSkill += 1;


                if (_currentSkill >= _maxskillPoint)
                {
                    int myIndex = CardSystem.instance.itemList.IndexOf(gameObject);
                    if (myIndex >= 0)
                    {
                        _countIdx = myIndex;
                        CardSystem.instance.itemList.RemoveAt(_countIdx);
                    }

                    gameObject.SetActive(false);
                }
                GameManager.Instance.MinusCoin(price);
                price += modifierValue;
                gameObject.SetActive(false);
                _boyFriend.speed += modifierValues;
                priceTxt.text = $"가격 : {price}원";
                return;
            }
            else
            {
                _skillCompo.AddSkill(_skillSO);
                Color color = _skillimage.color;
                color.a = 1;
                _skillimage.color = color;
                _skillSO = null;
                GameManager.Instance.MinusCoin(price);
                price += modifierValue;
                gameObject.SetActive(false);
                priceTxt.text = $"가격 : {price}원";
                return;
            }
        }
        else return;
    }
}
