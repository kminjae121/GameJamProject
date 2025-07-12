using UnityEngine;

namespace Code.Entities
{
    [CreateAssetMenu(fileName = "PlayerSO", menuName = "SO/Player", order = 0)]
    public class PlayerSO : ScriptableObject
    {
        public int projectileCount;
    }
}