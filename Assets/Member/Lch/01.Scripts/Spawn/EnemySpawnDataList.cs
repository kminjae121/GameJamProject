using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnDataList", menuName = "SO/EnemySpawnDataList")]
public class EnemySpawnDataList : ScriptableObject
{
    public List<EnemySpawnData> datas;
}
