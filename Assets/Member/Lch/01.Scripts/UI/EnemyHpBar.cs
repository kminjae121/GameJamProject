using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    public void ApplyHealth(float health, float maxHealth)
    {
        float endHealth = health / maxHealth;
        healthBar.DOFillAmount(endHealth, .5f);
    }
}
