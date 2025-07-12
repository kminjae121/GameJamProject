using Code.Combat;
using DG.Tweening;
using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : Entity
{
    [SerializeField] private StatSO attackDamageStat;
    [SerializeField] private GameObject rightText;
    [SerializeField] private GameObject leftText;
    [SerializeField] private TextMeshPro leftMeshPro;
    [SerializeField] private TextMeshPro rightMeshPro;
    [SerializeField] private EnemyTextSO enemyTextList;
    [SerializeField] private float showTextTime;
    protected EnemyMovement movement;
    private EntityStat _statCompo;
    private bool _isShow;
    private float _currentTime;
    private int _textCount;
    private bool _hasPlayedTween = false;


    protected override void Awake()
    {
        base.Awake();
        movement = GetCompo<EnemyMovement>();
        _statCompo = GetCompo<EntityStat>();
        rightText.transform.DOScale(Vector2.zero, 0.2f);
        leftText.transform.DOScale(Vector2.zero, 0.2f);
    }

    private void Start()
    {
        int textShowIndx = Random.Range(0, 11);
        if (textShowIndx <= 3)
        {
            _isShow = true;

        }
        else
        {
            _isShow = false;
        }
    }

    public override void OnDead()
    {
        IsDead = true;
        DOVirtual.DelayedCall(0.5f, () => Destroy(gameObject));
        GameManager.Instance.AddKillCount(1);
    }

    public override void OnHit()
    {
        if (IsDead)
            return;
    }

    private async void Update()
    {
        if (_isShow)
        {
            _currentTime += Time.deltaTime;
            if(_currentTime > showTextTime && !_hasPlayedTween)
            {
                _hasPlayedTween =true;
                if (transform.position.x >= 0)
                {
                    rightText.transform.DOScale(0.2f, 0.4f).SetEase(Ease.OutBounce);
                    rightMeshPro.text = enemyTextList.text[_textCount];
                }
                else
                {
                    leftText.transform.DOScale(0.2f, 0.4f).SetEase(Ease.OutBounce);
                    leftMeshPro.text = enemyTextList.text[_textCount];
                }

                await Awaitable.WaitForSecondsAsync(1.5f);
                rightText.transform.DOScale(0, 0.1f).SetEase(Ease.OutBounce);
               leftText.transform.DOScale(0, 0.1f).SetEase(Ease.OutBounce);

                    _currentTime = 0;
           
                    if (_textCount >= enemyTextList.text.Count)
                    {
                        _textCount = 0;
                    }
                    _textCount++;
                    _hasPlayedTween = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(collision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                DamageData damageData = new DamageData();
                damageData.damage = _statCompo.GetStat(attackDamageStat).Value;
                damageData.isCritical = false;
                damageData.hitPoint = collision.contacts[0].point;
                damageData.hitNormal = collision.contacts[0].normal;
                Debug.Log(damageData.hitNormal);
                damageable.ApplyDamage(damageData, transform.position);
                Destroy(gameObject);
            }
        }
    }
}
