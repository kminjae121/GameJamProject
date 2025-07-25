using Member.KMJ._01.Scripts;
using UnityEngine;

public class HealSkillUpCompo : SkillUpCompo
{
    public void UpSkillLevel()
    {
        if (GameManager.Instance.coin >= price)
        {

            _skillCompo.AddSkill(_skillSO);
            Color color = _skillimage.color;
            color.a = 1;
            _skillimage.color = color;
            _skillSO = null;
            GameManager.Instance.MinusCoin(price);

            int myIndex = CardSystem.instance.itemList.IndexOf(gameObject);
            if (myIndex >= 0)
            {
                _countIdx = myIndex;
                CardSystem.instance.itemList.RemoveAt(_countIdx);
            }

            gameObject.SetActive(false);
            return;
        }

    }
}
