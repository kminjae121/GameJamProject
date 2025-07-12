using UnityEngine;

public class BookSkillUpCompo : SkillUpCompo
{
   [SerializeField] private Book bookCompo;
   public override void UpSkillLevel()
   {
      base.UpSkillLevel();
      bookCompo.coolTime -= 0.2f;
   }
}
