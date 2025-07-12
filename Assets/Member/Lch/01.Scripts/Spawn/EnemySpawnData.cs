using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "SO/Enemy/EnemyData")]
public class EnemySpawnData : ScriptableObject
{
    public string enemyName;
    public Enemy enemy = null;
    public int SpawnLevel = 0;
}
