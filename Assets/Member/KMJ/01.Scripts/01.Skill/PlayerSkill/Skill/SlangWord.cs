using System.Collections;
using DG.Tweening;
using UnityEngine;

public class SlangWord : SkillCompo
{
    public override void GetSkill()
    {
        base.GetSkill();
        StartCoroutine(shootTime());
    }

    [SerializeField] private GameObject _slangPrefab;

    [field: SerializeField] public float coolTime { get; set; }
    

    private IEnumerator shootTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(coolTime);
            
            GameObject obj = Instantiate(_slangPrefab, transform.position, Quaternion.identity);
            obj.transform.localScale = Vector3.zero;
            obj.transform.DOScale(1f, 0.7f).SetEase(Ease.OutBounce);
        }
    }
}
