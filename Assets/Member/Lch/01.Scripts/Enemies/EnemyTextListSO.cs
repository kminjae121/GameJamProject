using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTextListSO", menuName = "SO/EnemyTextListSO")]
public class EnemyTextListSO : ScriptableObject
{
    public List<EnemyTextSO> enemyTexts;
}
