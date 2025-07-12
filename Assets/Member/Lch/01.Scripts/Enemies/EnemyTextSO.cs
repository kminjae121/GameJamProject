using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTextSO", menuName = "SO/EnemyTextSO")]
public class EnemyTextSO : ScriptableObject
{
    public List<string> text;
}
