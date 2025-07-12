using UnityEngine;

namespace Code.Player
{
    [CreateAssetMenu(fileName = "PlayerSO", menuName = "SO/Player", order = 0)]
    public class PlayerSO : ScriptableObject
    {
        public int projectileCount;
    }
}