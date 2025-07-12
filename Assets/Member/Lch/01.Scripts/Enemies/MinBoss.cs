using Code.Combat;
using DG.Tweening;
using TMPro;
using Unity.AppUI.UI;
using UnityEngine;

public class MinBoss : Entity
{
    [SerializeField] private EnemySpawnData spawnData;
    [SerializeField] private StatSO attackDamageStat;
    [SerializeField] private GameObject rightText;
    [SerializeField] private GameObject leftText;
    [SerializeField] private TextMeshPro leftMeshPro;
    [SerializeField] private TextMeshPro rightMeshPro;
    [SerializeField] private EnemyTextSO enemyTextList;
    [SerializeField] private float radius = 15;
    [SerializeField] private float showTextTime;
    [SerializeField] private float spawnTime;
    private EntityStat _statCompo;
    private bool _isShow;
    private float _currentTime;
    private float _currentSpawnerTime;
    private int _textCount;
    private bool _hasPlayedTween = false;


    protected override void Awake()
    {
        base.Awake();
        _statCompo = GetCompo<EntityStat>();
        rightText.transform.DOScale(Vector2.zero, 0.2f);
        leftText.transform.DOScale(Vector2.zero, 0.2f);
    }

    private void Start()
    {
        _isShow = true;
    }

    public override void OnDead()
    {
        IsDead = true;
        DOTween.Kill(rightText.transform);
        DOTween.Kill(leftText.transform);
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
        if (IsDead || !this || !gameObject) return;

        if (_isShow)
        {
            _currentTime += Time.deltaTime;
            if (_currentTime > showTextTime && !_hasPlayedTween)
            {
                _hasPlayedTween = true;

                bool isRight = transform.position.x >= 0;
                TextMeshPro meshPro = isRight ? rightMeshPro : leftMeshPro;
                GameObject textObject = isRight ? rightText : leftText;


                    textObject.transform.DOScale(0.1f, 0.4f).SetEase(Ease.OutBounce);
                    meshPro.text = enemyTextList.text[_textCount];
                    DOVirtual.DelayedCall(5f, () => { });
                        textObject.transform.DOScale(0, 0.1f).SetEase(Ease.OutBounce); _currentTime = 0;
                    _textCount = (_textCount + 1) % enemyTextList.text.Count;
                    _hasPlayedTween = false;
            }
        }

        _currentSpawnerTime += Time.deltaTime;
        if (_currentSpawnerTime > spawnTime)
        {
                Vector3 spawnPos = Random.insideUnitCircle.normalized * radius;

                Enemy enemy = spawnData.enemy;
                enemy = Instantiate(enemy, spawnPos + transform.position, Quaternion.identity);
            _currentSpawnerTime = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent(out IDamageable damageable))
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
