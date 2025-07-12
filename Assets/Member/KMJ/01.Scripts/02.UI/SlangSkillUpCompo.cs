using Member.KMJ._01.Scripts;
using UnityEngine;

public class SlangSkillUpCompo : SkillUpCompo
{
    [SerializeField] private SlangWord _slangSkillUpCompo;
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

                _slangSkillUpCompo.coolTime -= 0.5f;
                GameManager.Instance.MinusCoin(price);
                price += modifierValue;
                gameObject.SetActive(false);
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
